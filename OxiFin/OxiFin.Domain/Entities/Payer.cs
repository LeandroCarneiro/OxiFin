using System.ComponentModel.DataAnnotations.Schema;

namespace OxiFin.Domain.Entities
{
    [Table("tblPayers")]
    public class Payer : EntityBase<long>
    {
        public string Name { get; set; }
        public decimal Incomes { get; set; }
        public long UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual UserApp User { get; set; }
    }
}
