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
            const string customerId = "655a6e17-70d7-40ba-9a1b-861eafbb842b";

            var admin = new IdentityUser()
            {
                Id = adminId,
                UserName = "admin@test.com",
                NormalizedUserName = "ADMIN@TEST.COM",
                Email = "admin@test.com",
                NormalizedEmail = "ADMIN@TEST.COM",
                EmailConfirmed = true,
            };

            var customer = new IdentityUser()
            {
                Id = customerId,
                UserName = "customer1@test.com",
                NormalizedUserName = "CUSTOMER1@TEST.COM",
                Email = "customer1@test.com",
                NormalizedEmail = "CUSTOMER1@TEST.COM",
                EmailConfirmed = true
            };

            var passwordHasher = new PasswordHasher<IdentityUser>();

            admin.PasswordHash = passwordHasher.HashPassword(admin, "123qweASD@");
            customer.PasswordHash = passwordHasher.HashPassword(customer, "123qweASD@");

            builder.HasData(admin, customer);

            #endregion
        }
    }
}