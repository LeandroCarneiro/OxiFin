using System.ComponentModel.DataAnnotations.Schema;

namespace OxiFin.Domain.Entities
{
    [Table("tbl_users")]
    public class UserApp : EntityBase<long>
    {        
        public string Username { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
