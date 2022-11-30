using BoardGamesShopMVC.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoardGamesShopMVC.Infrastructure.Configurations
{
    public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.HasOne(ca => ca.ApplicationUser).WithOne(cu => cu.Cart).HasForeignKey<Cart>(ca => ca.ApplicationUserId);
            builder.HasMany(ca => ca.CartItems).WithOne(ci => ci.Cart).HasForeignKey(ci => ci.CartId);

            #region DataSeed

            const string customerId = "655a6e17-70d7-40ba-9a1b-861eafbb842b";

            builder.HasData
            (
                new Cart() { Id = 1, ApplicationUserId = customerId }
            );

            #endregion
        }
    }
}
