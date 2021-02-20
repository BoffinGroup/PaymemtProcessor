using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PaymentProcessor.Domain.DTOs;

namespace PaymentProcessor.Domain.Services.ProcessPaymentService
{
    public interface IProcessPaymentService
    {
        Task<APIResponse> ProcessPayment(CardInfoDTO request);
    }
}
