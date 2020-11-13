using OxiFin.Common;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace OxiFin.Domain.Entities
{
    [Table("tblPayments")]
    public class Payment : EntityBase<long>
    {
        public long BillId { get; set; }
        public decimal Amount { get; set; }
        public ECurrency Currency { get; set; }
        public DateTime Date { get; set; }
        public long UserId { get; set; }

        [ForeignKey(nameof(BillId))]
        public virtual Bill Bill { get; set; }
    }
}
