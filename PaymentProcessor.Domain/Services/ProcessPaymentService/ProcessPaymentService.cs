using PaymentProcessor.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PaymentProcessor.Domain.Services.CheapPaymentGatewayService;
using PaymentProcessor.Domain.Services.ExpensivePaymentGatewayService;
using PaymentProcessor.Domain.Services.PremiumPaymentService;
using PaymentProcessor.Domain.Contracts;
using PaymentProcessor.Domain.Entities;
using PaymentProcessor.Domain.Helper;
using PaymentProcessor.Domain.Enum;

namespace PaymentProcessor.Domain.Services.ProcessPaymentService
{
    public class ProcessPaymentService : IProcessPaymentService
    {
        private readonly ICheapPaymentGateway _cheapPaymentGateway;
        private readonly IExpensivePaymentGateway _expensivePaymentGateway;
        private readonly IPremiumPayment _premiumPayment;
        private readonly IRepositoryWrapper _repositoryWrapper;
        public ProcessPaymentService(ICheapPaymentGateway cheapPaymentGateway, IExpensivePaymentGateway expensivePaymentGateway, IPremiumPayment premiumPayment, IRepositoryWrapper repositoryWrapper)
        {
            _cheapPaymentGateway = cheapPaymentGateway;
            _expensivePaymentGateway = expensivePaymentGateway;
            _premiumPayment = premiumPayment;
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<APIResponse> ProcessPayment(CardInfoDTO request)
        {
            var response = new APIResponse();
            try
            {
                var amount = request.Amount;
                if(amount < 20)
                {
                    response = await _cheapPaymentGateway.ProcessCheapPayment(request);
                }
                else if (amount >= 21 && amount <= 500)
                {
                    if(_expensivePaymentGateway != null)
                    {
                        response = await _expensivePaymentGateway.ProcessExpensivePayment(request);
                    }
                    else
                    {
                        response = await _cheapPaymentGateway.ProcessCheapPayment(request);
                    }
                    
                }
                else if (amount > 500)
                {
                    int count = 0;
                    response = await _premiumPayment.ProcessPremiumPayment(request);
                    if(response.Code == "99")
                    {
                        while (response.Code == "99" && count <=3)
                        {
                            response = await _premiumPayment.ProcessPremiumPayment(request);
                            count++;
                        }
                    }
                }
                else
                {
                    response = new APIResponse {Code="99", Description="Your payment cannot be processed", Data="" };
                }

                var paymentState = new PaymentState();
                paymentState.CorrelationId = Guid.NewGuid().ToString();
                paymentState.PayDate = DateTime.Now;
                paymentState.RequestString = JsonTranformer.SerializeObject(request);
                paymentState.ResponseString = JsonTranformer.SerializeObject(response);
                if(response.Code == "00")
                {
                    paymentState.State = State.processed;
                }
                if(response.Code == "99")
                {
                    paymentState.State = State.failed;
                }
                else
                {
                    paymentState.State = State.pending;
                }

                _repositoryWrapper.PaymentStateRepository.Create(paymentState);
                await _repositoryWrapper.SaveAsync();

               
            }
            catch(Exception)
            {
                response  = new APIResponse { Code = "99", Description = "Internal Server Error", Data = "" };
                throw;
            }
            return response;
        }
    }
}
