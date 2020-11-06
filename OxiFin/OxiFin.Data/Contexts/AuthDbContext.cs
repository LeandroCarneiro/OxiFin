using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using OxiFin.Domain.Entities.Auth;
using OxiFin.DI;
using Microsoft.Extensions.Logging;

namespace OxiFin.Data.Contexts
{
    public class AuthDbContext : IdentityDbContext<UserApp, Role, long, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
    {
        protected readonly IConfiguration _configuration;
        protected readonly ILoggerFactory _loggerFactory;
        protected readonly ILogger _log;

        public AuthDbContext()
        {
            _loggerFactory = AppContainer.Resolve<ILoggerFactory>();
            _configuration = AppContainer.Resolve<IConfiguration>();

            _log = _loggerFactory.CreateLogger<BaseContext>();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseMySQL(_configuration.GetConnectionString("OxiFinAuthDB"));
            base.OnConfiguring(options);

            options.UseLoggerFactory(_loggerFactory);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
