using BoardGamesShopMVC.Application.ViewModels.Cart;

namespace BoardGamesShopMVC.Application.Interfaces
{
    public interface IOrderService
    {
        int CreateOrder(CartSummaryVm cartVm, string userId);
    }
}
