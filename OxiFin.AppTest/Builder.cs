using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Moq;
using OxiFin.Bootstrap;
using System.IO;
using System.Linq;

namespace OxiFin.AppTest
{
    public static class Builder
    {
        static IServiceCollection _container;

        public static void Setup()
        {
            if (_container == null)
            {
                _container = new ServiceCollection();
                _container.AddSingleton(GetConfiguration());
                _container.AddSingleton(new Mock<ILoggerProvider>().Object);
                _container.AddSingleton(new Mock<ILoggerFactory>().Object);
                _container.AddSingleton(new Mock<ILogger>().Object);

                DIBootstrap.MockRegisterTypes(_container);
            }
        }

        public static IConfiguration GetConfiguration()
        {
            var current = Directory.GetCurrentDirectory();
            var directories = Directory.GetParent(current)
                .Parent.Parent.Parent.GetDirectories();
            var config = directories.Where(x => x.Name == "OxiFin")?.First()?.FullName + "\\OxiFin.Api";

            return new ConfigurationBuilder()
            .SetBasePath(config)
            .AddJsonFile("appsettings.json")
            .Build();
        }
    }
}
