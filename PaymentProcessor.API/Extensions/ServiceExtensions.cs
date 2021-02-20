
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PaymentProcessor.Domain.Contexts;
using Microsoft.EntityFrameworkCore;
using PaymentProcessor.Domain.Contracts;
using PaymentProcessor.Domain.Repository;
using PaymentProcessor.Domain.Services.CheapPaymentGatewayService;
using PaymentProcessor.Domain.Services.ExpensivePaymentGatewayService;
using PaymentProcessor.Domain.Services.PremiumPaymentService;
using PaymentProcessor.Domain.Services.ProcessPaymentService;

namespace PaymentProcessor.API.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureRepositoryContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RepositoryContext>(x => x.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }

        public static void ConfigureRepository(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
            services.AddScoped<ICheapPaymentGateway, CheapPaymentGateway>();
            services.AddScoped<IExpensivePaymentGateway, ExpensivePaymentGateway>();
            services.AddScoped<IPremiumPayment, PremiumPayment>();
            services.AddScoped<IProcessPaymentService, ProcessPaymentService>();
        }
    }
}
