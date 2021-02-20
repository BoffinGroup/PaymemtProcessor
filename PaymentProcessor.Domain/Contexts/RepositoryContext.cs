using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using PaymentProcessor.Domain.Entities;

namespace PaymentProcessor.Domain.Contexts
{
    public  class RepositoryContext:DbContext
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options):base(options)
        {

        }

        public DbSet<CardInfo> CardInfos { get; set; }
        public DbSet<PaymentState> PaymentStates { get; set; }
    }
}
