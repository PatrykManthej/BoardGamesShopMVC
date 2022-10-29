using BoardGamesShopMVC.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoardGamesShopMVC.Infrastructure.Configurations
{
    public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.HasOne(ca => ca.Customer).WithOne(cu => cu.Cart).HasForeignKey<Cart>(ca => ca.CustomerId);
            builder.HasMany(ca => ca.CartItems).WithOne(ci => ci.Cart).HasForeignKey(ci => ci.CartId);

            #region DataSeed

            builder.HasData
            (
                new Cart() { Id = 1, CustomerId = 1 }
            );

            #endregion
        }
    }
}
