using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace OxiFin.Domain.Entities.Auth
{
    [Table("tblRoles")]
    public class Role : IdentityRole<long>
    { 
    
    }

    [Table("tblRoleClaims")]
    public class RoleClaim : IdentityRoleClaim<long>
    {
    }
}
