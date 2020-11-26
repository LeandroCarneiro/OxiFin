using OxiFin.Application.AppServices;
using OxiFin.Business.Domain;
using OxiFin.Data.Contexts;
using OxiFin.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using OxiFin.Domain.Entities.Auth;
using OxiFin.Domain.Entities;
using OxiFin.Application;
using OxiFin.Business.App;

namespace OxiFin.Bootstrap
{
    public static class BigContainer
    {
        public static IServiceCollection RegisterAuthServices(this IServiceCollection service)
        {
            service.AddTransient<UserAppService>();
            service.AddTransient<LoginAppService>();
            service.AddTransient<UserManager<UserApp>>();

            return service;
        }

        public static IServiceCollection RegisterAuthBusiness(this IServiceCollection service)
        {
            return service;
        }
        
        public static IServiceCollection RegisterAuthPersistence(this IServiceCollection service)
        {
            service.AddDbContext<AuthDbContext>();
            return service;
        }

        public static IServiceCollection RegisterAppServices(this IServiceCollection service)
        {
            service.AddTransient<BankAccountAppService>();
            service.AddTransient<DebitAppService>();
            service.AddTransient<DebtorAppService>();
            service.AddTransient<PayerAppService>();
            
            return service;
        }

        public static IServiceCollection RegisterAppBusiness(this IServiceCollection service)
        {
            service.AddTransient<IBusiness<Debtor>, DebtorBusiness>();
            service.AddTransient<IBusiness<BankAccount>, BankAccountBusiness>();
            service.AddTransient<IBusiness<Payer>, PayerBusiness>();
            service.AddTransient<IBusiness<Debit>, DebitBusiness>();
            service.AddTransient<IBusiness<Bill>, BillBusiness>();
            service.AddTransient<IBusiness<Payment>, PaymentBusiness>();

            return service;
        }
        
        public static IServiceCollection RegisterAppPersistence(this IServiceCollection service)
        {
            service.AddDbContext<AuthDbContext>();
            service.AddTransient<IDbContext, MySqlDbContext>();
            return service;
        }


        public static IServiceCollection MockRegisterAppPersistence(this IServiceCollection service)
        {
            service.AddDbContext<MockDbContext>();
            service.AddTransient<IDbContext, MockDbContext>();
            return service;
        }
    }
}
