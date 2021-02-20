using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PaymentProcessor.Domain.DTOs;

namespace PaymentProcessor.Domain.Services.CheapPaymentGatewayService
{
    public interface ICheapPaymentGateway
    {
        Task<APIResponse> ProcessCheapPayment(CardInfoDTO cardInfo);
    }
}
