using System.ComponentModel.DataAnnotations.Schema;

namespace OxiFin.Domain.Entities
{
    [Table("tblDebts")]
    public class Debit
    {
        public string Description { get; set; }
        public long DebtorId { get; set; }
        public long PayerId { get; set; }
        public decimal Total { get; set; }
        
        [ForeignKey(nameof(DebtorId))]
        public Debtor Debtor { get; set; }
        [ForeignKey(nameof(PayerId))]
        public Payer Payer { get; set; }
    }
}
