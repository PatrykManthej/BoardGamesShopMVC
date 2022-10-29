using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoardGamesShopMVC.Infrastructure.Configurations.Identity
{
    public class IdentityRoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            #region DataSeed

            builder.HasData
            (
                new IdentityRole { Id = "Admin", Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Id = "Employee", Name = "Employee", NormalizedName = "EMPLOYEE" },
                new IdentityRole { Id = "User", Name = "User", NormalizedName = "USER" }
            );

            #endregion
        }
    }
}