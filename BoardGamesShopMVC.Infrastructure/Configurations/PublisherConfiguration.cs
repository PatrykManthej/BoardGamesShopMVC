using BoardGamesShopMVC.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoardGamesShopMVC.Infrastructure.Configurations
{
    public class PublisherConfiguration : IEntityTypeConfiguration<Publisher>
    {
        public void Configure(EntityTypeBuilder<Publisher> builder)
        {
            builder.Property(p => p.Name).HasMaxLength(50).IsRequired();

            #region DataSeed

            builder.HasData
            (
                new Publisher() { Id = 1, Name = "Bard", StatusId = 1 },
                new Publisher() { Id = 2, Name = "Rebel", StatusId = 1 },
                new Publisher() { Id = 3, Name = "Albi", StatusId = 1 },
                new Publisher() { Id = 4, Name = "Lucky Duck Games", StatusId = 1 },
                new Publisher() { Id = 5, Name = "Lacerta", StatusId = 1 }
            );

            #endregion
        }
    }
}
