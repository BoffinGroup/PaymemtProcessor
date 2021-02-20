using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PaymentProcessor.Domain.DTOs;

namespace PaymentProcessor.Domain.Services.PremiumPaymentService
{
    public class PremiumPayment : IPremiumPayment
    {
        public async Task<APIResponse> ProcessPremiumPayment(CardInfoDTO cardInfo)
        {
            return await Task.Run(() => new APIResponse { Code = "00", Description = "Success", Data = "" });
        }
    }
}
