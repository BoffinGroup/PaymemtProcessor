using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PaymentProcessor.Domain.DTOs;

namespace PaymentProcessor.Domain.Services.ExpensivePaymentGatewayService
{
    public class ExpensivePaymentGateway : IExpensivePaymentGateway
    {
        public async Task<APIResponse> ProcessExpensivePayment(CardInfoDTO request)
        {
            return await Task.Run(() => new APIResponse {  });
        }
    }
}
