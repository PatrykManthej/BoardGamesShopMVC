using BoardGamesShopMVC.Application.Interfaces;
using BoardGamesShopMVC.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

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
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IPaymentService, PaymentService>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
