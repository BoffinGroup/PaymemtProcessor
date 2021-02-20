using System;
using System.Collections.Generic;
using System.Text;
using PaymentProcessor.Domain.Contracts;
using PaymentProcessor.Domain.Contexts;
using System.Threading.Tasks;

namespace PaymentProcessor.Domain.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private IPaymentStateRepository _stateRepository;
        private  RepositoryContext _repositoryContext;
        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }
        public IPaymentStateRepository PaymentStateRepository
        {
            get
            {
                if(_stateRepository == null)
                {
                    return _stateRepository = new PaymentStateRepository(_repositoryContext);
                }
                return _stateRepository;
            }
        }

        public async Task SaveAsync()
        {
           await _repositoryContext.SaveChangesAsync();
        }
    }
}
