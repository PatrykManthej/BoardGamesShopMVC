using BoardGamesShopMVC.Domain.Interfaces;
using BoardGamesShopMVC.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BoardGamesShopMVC.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IBoardGameRepository, BoardGameRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IPublisherRepository, PublisherRepository>();
            services.AddTransient<ICartRepository, CartRepository>();
            services.AddTransient<ILanguageRepository, LanguageRepository>();
            services.AddTransient<IStockRepository, StockRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            return services;
        }
    }
}
