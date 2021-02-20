using PaymentProcessor.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PaymentProcessor.Domain.Services.ExpensivePaymentGatewayService
{
    public interface IExpensivePaymentGateway
    {
        Task<APIResponse> ProcessExpensivePayment(CardInfoDTO request);
    }
}
