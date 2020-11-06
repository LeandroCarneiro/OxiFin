using Microsoft.AspNetCore.Identity;

namespace OxiFin.Domain.Entities.Auth
{
    public class Role : IdentityRole<long>
    { 
    
    }

    public class RoleClaim : IdentityRoleClaim<long>
    {
    }
}
