using BoardGamesShopMVC.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoardGamesShopMVC.Infrastructure.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            #region DataSeed

            builder.HasData
            (
                new Category() { Id = 1, Name = "Strategiczne", StatusId = 1 },
                new Category() { Id = 2, Name = "Przygodowe", StatusId = 1 },
                new Category() { Id = 3, Name = "Rodzinne", StatusId = 1 },
                new Category() { Id = 4, Name = "Imprezowe", StatusId = 1 }
            );

            #endregion
        }
    }
}
