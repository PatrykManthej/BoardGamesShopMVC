using BoardGamesShopMVC.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoardGamesShopMVC.Infrastructure.Configurations
{
    public class BoardGameCategoryConfiguration : IEntityTypeConfiguration<BoardGameCategory>
    {
        public void Configure(EntityTypeBuilder<BoardGameCategory> builder)
        {
            #region DataSeed

            builder.HasData
            (
                new BoardGameCategory() { BoardGamesId = 1, CategoriesId = 1 },
                new BoardGameCategory() { BoardGamesId = 2, CategoriesId = 1 },
                new BoardGameCategory() { BoardGamesId = 3, CategoriesId = 2 },
                new BoardGameCategory() { BoardGamesId = 4, CategoriesId = 3 },
                new BoardGameCategory() { BoardGamesId = 5, CategoriesId = 2 },
                new BoardGameCategory() { BoardGamesId = 6, CategoriesId = 1 },
                new BoardGameCategory() { BoardGamesId = 7, CategoriesId = 3 },
                new BoardGameCategory() { BoardGamesId = 8, CategoriesId = 3 },
                new BoardGameCategory() { BoardGamesId = 9, CategoriesId = 4 },
                new BoardGameCategory() { BoardGamesId = 10, CategoriesId = 3 },
                new BoardGameCategory() { BoardGamesId = 11, CategoriesId = 1 },
                new BoardGameCategory() { BoardGamesId = 12, CategoriesId = 1 }
            );

            #endregion
        }
    }
}
