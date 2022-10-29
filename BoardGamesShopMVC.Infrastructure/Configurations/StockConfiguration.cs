using BoardGamesShopMVC.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoardGamesShopMVC.Infrastructure.Configurations
{
    public class StockConfiguration : IEntityTypeConfiguration<Stock>
    {
        public void Configure(EntityTypeBuilder<Stock> builder)
        {
            #region DataSeed

            builder.HasData
            (
                new Stock() { Id = 1, Quantity = 5, StatusId = 1 },
                new Stock() { Id = 2, Quantity = 7, StatusId = 1 },
                new Stock() { Id = 3, Quantity = 2, StatusId = 1 },
                new Stock() { Id = 4, Quantity = 4, StatusId = 1 },
                new Stock() { Id = 5, Quantity = 3, StatusId = 1 },
                new Stock() { Id = 6, Quantity = 6, StatusId = 1 },
                new Stock() { Id = 7, Quantity = 2, StatusId = 1 },
                new Stock() { Id = 8, Quantity = 3, StatusId = 1 },
                new Stock() { Id = 9, Quantity = 2, StatusId = 1 },
                new Stock() { Id = 10, Quantity = 2, StatusId = 1 },
                new Stock() { Id = 11, Quantity = 5, StatusId = 1 },
                new Stock() { Id = 12, Quantity = 6, StatusId = 1 }
            );

            #endregion
        }
    }
}