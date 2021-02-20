using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PaymentProcessor.Domain.DTOs;

namespace PaymentProcessor.Domain.Services.PremiumPaymentService
{
    public interface IPremiumPayment
    {
        Task<APIResponse> ProcessPremiumPayment(CardInfoDTO cardInfo);
    }
}
