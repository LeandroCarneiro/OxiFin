using OxiFin.Domain.Entities;
using OxiFin.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace OxiFin.Data.Contexts
{
    public class MySqlDbContext : BaseContext, IDbContext
    {
        public virtual DbSet<Debtor> tblDebtors { get; set; }
        public virtual DbSet<Debit> tblDebts { get; set; }
        public virtual DbSet<Payer> tblPayers { get; set; }
        public virtual DbSet<Payment> tblPayments { get; set; }
        public virtual DbSet<BankAccount> tblBankAccounts { get; set; }
        public virtual DbSet<Bill> tblBills { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseMySQL(_configuration.GetConnectionString("OxiFinDB"));
            base.OnConfiguring(options);

            options.UseLoggerFactory(_loggerFactory);
        }
    }
}
