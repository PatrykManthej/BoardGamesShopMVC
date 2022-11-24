using BoardGamesShopMVC.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoardGamesShopMVC.Infrastructure.Configurations
{
    public class ShopUserConfiguration : IEntityTypeConfiguration<ShopUser>
    {
        public void Configure(EntityTypeBuilder<ShopUser> builder)
        {
            builder.HasMany(u => u.Addresses).WithOne(a => a.ShopUser).HasForeignKey(a => a.ShopUserId);
            builder.HasMany(u => u.Recipients).WithOne(r => r.ShopUser).HasForeignKey(r => r.ShopUserId);
            

            #region DataSeed

            const string identityUserId = "655a6e17-70d7-40ba-9a1b-861eafbb842b";

            builder.HasData
            (
                new ShopUser() { Id = 1, IdentityUserId = identityUserId, Email = "User1@test.com" }
            );

            #endregion
        }
    }
}
