using BoardGamesShopMVC.Application.ViewModels.Cart;
using BoardGamesShopMVC.Domain.Model;

namespace BoardGamesShopMVC.Application.Interfaces
{
    public interface ICartService
    {
        CartDetailsVm GetCart(string applicationUserId);
        int CreateCart(string applicationUserId);
        void AddItemToCart(int boardGameId, int cartId);
        void DeleteCartItemFromCart(int cartItemId);
        void IncrementCartItemQuantity(int cartItemId);
        void DecrementCartItemQuantity(int cartItemId);
        CartSummaryVm GetCartSummary(ApplicationUser user);
        void ClearCart(int cartId);
    }
}
