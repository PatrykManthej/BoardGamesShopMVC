using BoardGamesShopMVC.Application.Interfaces;
using BoardGamesShopMVC.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BoardGamesShopMVC.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<IBoardGameService, BoardGameService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IPublisherService, PublisherService>();
            services.AddTransient<ICartService, CartService>();
            services.AddTransient<ICustomerService, CustomerService>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
