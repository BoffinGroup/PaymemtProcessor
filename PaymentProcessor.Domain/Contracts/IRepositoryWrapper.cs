using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PaymentProcessor.Domain.Contracts
{
    public interface IRepositoryWrapper
    {
        IPaymentStateRepository PaymentStateRepository { get; }

        Task SaveAsync();
    }
}
