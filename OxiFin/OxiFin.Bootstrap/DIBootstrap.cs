using OxiFin.Data.Contexts;
using OxiFin.DI;
using OxiFin.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace OxiFin.Bootstrap
{
    public static class DIBootstrap
    {
        public static void RegisterTypes(IServiceCollection service)
        {
            service.RegisterAppServices()
                .RegisterAppBusiness()
                .RegisterAppPersistence();

            AppContainer.SetContainer(service);
            AutoMapperConfiguration.Register();

            Migrate(service);
        }

        public static void MockRegisterTypes(IServiceCollection service)
        {
            service.RegisterAppServices()
                .RegisterAppBusiness()
                .MockRegisterAppPersistence();

            AppContainer.SetContainer(service);
            AutoMapperConfiguration.Register();

            service.BuildServiceProvider().GetService<MockDbContext>().Database.EnsureCreated();
        }

        private static void Migrate(IServiceCollection services)
        {
            var dao = services.BuildServiceProvider().GetService<MySqlDbContext>();
            dao.Database.EnsureCreated();
            //dao.Database.Migrate();
        }
    }
}