using System.ComponentModel.DataAnnotations.Schema;

namespace OxiFin.Domain.Entities
{
    [Table("tblDebtors")]
    public class Debtor : UserApp
    {
        public string Name { get; set; }
        public string CPF { get; set; }
        public long UserId { get; set; }
        public long BankAccountId { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual UserApp CreatedBy { get; set; }
        [ForeignKey(nameof(BankAccountId))]
        public BankAccount BankAccount { get; set; }
    }
}
