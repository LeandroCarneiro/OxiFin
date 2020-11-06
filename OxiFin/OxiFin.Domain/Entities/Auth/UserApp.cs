using Microsoft.AspNetCore.Identity;
using OxiFin.Common.InternalObjects;
using System.ComponentModel.DataAnnotations.Schema;

namespace OxiFin.Domain.Entities.Auth
{
    [Table("tblUsers")]
    public class UserApp : IdentityUser<long>, IEntity<long>
    {        
        public string Username { get; set; }
        public string Phone { get; set; }
        public bool Active { get; set; }
    }
}
