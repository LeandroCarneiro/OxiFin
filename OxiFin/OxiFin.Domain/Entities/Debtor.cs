using System.ComponentModel.DataAnnotations.Schema;

namespace OxiFin.Domain.Entities
{
    [Table("tbl_survey_version")]
    public class Debtor : EntityBase<long>
    {
        public long UserId { get; set; }
        public string Name { get; set; }
        public int MyProperty { get; set; }
        [ForeignKey(nameof(UserId))]
        public virtual UserApp CreatedBy { get; set; }
    }
}
