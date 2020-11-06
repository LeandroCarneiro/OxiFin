using System.ComponentModel.DataAnnotations.Schema;

namespace OxiFin.Domain.Entities
{
    [Table("tblDebtors")]
    public class Debtor : EntityBase<long>
    {
        public string Name { get; set; }
        public string CPF { get; set; }
        public long UserId { get; set; }
        public long BankAccountId { get; set; }

        [ForeignKey(nameof(BankAccountId))]
        public virtual BankAccount BankAccount { get; set; }
    }
}
