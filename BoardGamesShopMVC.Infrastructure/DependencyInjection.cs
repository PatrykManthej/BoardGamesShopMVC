using BoardGamesShopMVC.Domain.Interfaces;
using BoardGamesShopMVC.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return services;
        }
    }
}
