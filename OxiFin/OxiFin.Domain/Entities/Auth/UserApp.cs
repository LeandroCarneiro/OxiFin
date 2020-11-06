using Microsoft.AspNetCore.Identity;
using OxiFin.Common.InternalObjects;
using System.ComponentModel.DataAnnotations;

namespace OxiFin.Domain.Entities.Auth
{
    public class UserApp : IdentityUser<long>, IEntity<long>
    {        
        public string Phone { get; set; }
        public bool Active { get; set; }
    }

    public class UserLogin : IdentityUserLogin<long>
    {
        [Key]
        public long Id { get; set; }
    }

    public class UserToken : IdentityUserToken<long>
    {
        [Key]
        public long Id { get; set; }
    }
    
    public class UserClaim : IdentityUserClaim<long>
    {
    }
    
    public class UserRole : IdentityUserRole<long>
    {
        [Key]
        public long Id { get; set; }
    }
    
}
