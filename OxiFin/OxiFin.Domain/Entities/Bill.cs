using OxiFin.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace OxiFin.Domain.Entities
{
    [Table("tblBills")]
    public class Bill : EntityBase<long>
    {
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public ECurrency Currency { get; set; }
        public long DebtorId { get; set; }
        
        [ForeignKey(nameof(DebtorId))]
        public Debtor Debtor { get; set; }
    }
}
