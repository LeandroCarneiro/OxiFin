using OxiFin.Domain.Entities;
using OxiFin.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace OxiFin.Data.Contexts
{
    public class TeslaDbContext : BaseContext, IDbContext
    {
        public virtual DbSet<UserApp> tblUsers { get; set; }
        public virtual DbSet<Debtor> tblDebtors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(_configuration.GetConnectionString("TeslaDB"));
            base.OnConfiguring(options);

            options.UseLoggerFactory(_loggerFactory);
        }
    }
}
