using OxiFin.Application.AppServices;
using OxiFin.Application.Interfaces;
using OxiFin.Business.Domain;
using OxiFin.Data.Contexts;
using OxiFin.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using OxiFin.Business.Auth;
using Microsoft.AspNetCore.Identity;
using OxiFin.Domain.Entities.Auth;

namespace OxiFin.Bootstrap
{
    public static class BigContainer
    {
        public static IServiceCollection RegisterAppServices(this IServiceCollection service)
        {
            service.AddTransient<UserAppService>();
            service.AddTransient<LoginAppService>();
            service.AddTransient<UserManager<UserApp>>();

            return service;
        }

        public static IServiceCollection RegisterAppBusiness(this IServiceCollection service)
        {
            service.AddTransient<IUserBusiness, UserBusiness>();
            service.AddTransient<ILoginBusiness, LoginBusiness>();
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
