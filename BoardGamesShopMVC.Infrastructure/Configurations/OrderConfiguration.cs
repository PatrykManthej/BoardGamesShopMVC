using BoardGamesShopMVC.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoardGamesShopMVC.Infrastructure.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasOne(o => o.ShopUser).WithMany(c => c.Orders).HasForeignKey(o => o.ShopUserId);
            builder.HasMany(o => o.Items).WithOne(i => i.Order).HasForeignKey(i => i.OrderId);

        }
    }
}
