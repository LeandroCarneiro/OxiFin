using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using OxiFin.Domain.Entities;
using OxiFin.Domain.Interfaces;

namespace OxiFin.Data.Contexts
{
    public class MockDbContext : BaseContext, IDbContext
    {
        public virtual DbSet<UserApp> tblUsers { get; set; }
        public virtual DbSet<Debtor> tblSurveyVersions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseInMemoryDatabase("OxiFinDB");
            options.ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning));

            base.OnConfiguring(options);
        }
    }
}
