using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoardGamesShopMVC.Infrastructure.Configurations.Identity
{
    public class IdentityUserConfiguration : IEntityTypeConfiguration<IdentityUser>

    {
        public void Configure(EntityTypeBuilder<IdentityUser> builder)
        {
            #region DataSeed

            const string adminId = "3937b908 - 3ed5 - 4b6d - abf8 - 0ec70e3a18ca";
            const string identityUserId = "655a6e17-70d7-40ba-9a1b-861eafbb842b";

            var admin = new IdentityUser()
            {
                Id = adminId,
                UserName = "admin1@test.com",
                NormalizedUserName = "ADMIN1@TEST.COM",
                Email = "admin1@test.com",
                NormalizedEmail = "ADMIN1@TEST.COM",
                EmailConfirmed = true,
            };

            var identityUser = new IdentityUser()
            {
                Id = identityUserId,
                UserName = "user1@test.com",
                NormalizedUserName = "USER1@TEST.COM",
                Email = "user1@test.com",
                NormalizedEmail = "USER1@TEST.COM",
                EmailConfirmed = true
            };

            var passwordHasher = new PasswordHasher<IdentityUser>();

            admin.PasswordHash = passwordHasher.HashPassword(admin, "123qweASD@");
            identityUser.PasswordHash = passwordHasher.HashPassword(identityUser, "123qweASD@");

            builder.HasData(admin, identityUser);

            #endregion
        }
    }
}