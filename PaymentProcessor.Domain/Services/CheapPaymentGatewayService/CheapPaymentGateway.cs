using PaymentProcessor.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PaymentProcessor.Domain.Services.CheapPaymentGatewayService
{
    public class CheapPaymentGateway : ICheapPaymentGateway
    {
        public async Task<APIResponse> ProcessCheapPayment(CardInfoDTO cardInfo)
        {
            return await Task.Run(() => new APIResponse { });
        }
    }
}
