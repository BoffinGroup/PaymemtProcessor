using System;
using System.Collections.Generic;
using System.Text;
using PaymentProcessor.Domain.Entities;

namespace PaymentProcessor.Domain.Contracts
{
    public interface IPaymentStateRepository:IRepositoryBase<PaymentState>
    {
    }
}
