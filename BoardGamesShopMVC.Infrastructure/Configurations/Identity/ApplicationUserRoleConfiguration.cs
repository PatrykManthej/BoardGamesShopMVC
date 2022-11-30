using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoardGamesShopMVC.Infrastructure.Configurations.Identity
{
    public class ApplicationUserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            #region DataSeed

            const string adminId = "3937b908 - 3ed5 - 4b6d - abf8 - 0ec70e3a18ca";
            const string customerId = "655a6e17-70d7-40ba-9a1b-861eafbb842b";

            builder.HasData
            (
                new IdentityUserRole<string>() { RoleId = "Admin", UserId = adminId },
                new IdentityUserRole<string>() { RoleId = "User", UserId = customerId }
            );

            #endregion
        }
    }
}