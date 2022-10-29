using BoardGamesShopMVC.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoardGamesShopMVC.Infrastructure.Configurations
{
    public class LanguageConfiguration : IEntityTypeConfiguration<Language>
    {
        public void Configure(EntityTypeBuilder<Language> builder)
        {
            #region DataSeed

            builder.HasData
            (
                new Language() { Id = 1, Name = "Polski", StatusId = 1 },
                new Language() { Id = 2, Name = "Angielski", StatusId = 1 }
            );

            #endregion
        }
    }
}
