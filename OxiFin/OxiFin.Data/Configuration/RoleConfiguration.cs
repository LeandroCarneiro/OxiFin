using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OxiFin.Domain.Entities.Auth;

namespace OxiFin.Data.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasData(
            new Role
            {
                Id = 1,
                Name = "Administrator",
                NormalizedName = "ADMINISTRATOR"
            },
            new Role
            {
                Id = 2,
                Name = "Visitor",
                NormalizedName = "VISITOR"
            });
        }
    }
}
