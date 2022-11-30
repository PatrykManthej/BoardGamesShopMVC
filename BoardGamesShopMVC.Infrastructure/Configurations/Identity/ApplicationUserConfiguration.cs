using BoardGamesShopMVC.Domain.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoardGamesShopMVC.Infrastructure.Configurations.Identity
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>

    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasMany(u => u.Addresses).WithOne(a => a.ApplicationUser).HasForeignKey(a => a.ApplicationUserId);
            builder.HasMany(u => u.Recipients).WithOne(r => r.ApplicationUser).HasForeignKey(r => r.ApplicationUserId);
            #region DataSeed

            const string adminId = "3937b908 - 3ed5 - 4b6d - abf8 - 0ec70e3a18ca";
            const string customerId = "655a6e17-70d7-40ba-9a1b-861eafbb842b";

            var admin = new ApplicationUser()
            {
                Id = adminId,
                UserName = "admin1@test.com",
                NormalizedUserName = "ADMIN1@TEST.COM",
                Email = "admin1@test.com",
                NormalizedEmail = "ADMIN1@TEST.COM",
                EmailConfirmed = true,
            };

            var customer = new ApplicationUser()
            {
                Id = customerId,
                UserName = "user1@test.com",
                NormalizedUserName = "USER1@TEST.COM",
                Email = "user1@test.com",
                NormalizedEmail = "USER1@TEST.COM",
                EmailConfirmed = true
            };

            var passwordHasher = new PasswordHasher<ApplicationUser>();

            admin.PasswordHash = passwordHasher.HashPassword(admin, "123qweASD@");
            customer.PasswordHash = passwordHasher.HashPassword(customer, "123qweASD@");

            builder.HasData(admin, customer);

            #endregion
        }
    }
}