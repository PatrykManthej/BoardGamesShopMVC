using BoardGamesShopMVC.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoardGamesShopMVC.Infrastructure.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            #region DataSeed

            const string customerId = "655a6e17-70d7-40ba-9a1b-861eafbb842b";

            builder.HasData
            (
                new Customer() { Id = 1, UserId = customerId }
            );

            #endregion
        }
    }
}
