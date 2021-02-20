using System;
using System.Collections.Generic;
using System.Text;
using PaymentProcessor.Domain.Entities;
using PaymentProcessor.Domain.Contracts;
using PaymentProcessor.Domain.Contexts;

namespace PaymentProcessor.Domain.Repository
{
   public  class PaymentStateRepository:RepositoryBase<PaymentState>, IPaymentStateRepository
    {
        public PaymentStateRepository(RepositoryContext repositoryContext):base(repositoryContext)
        {

        }

    }
}
