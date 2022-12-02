using BoardGamesShopMVC.Application.ViewModels.Cart;

namespace BoardGamesShopMVC.Application.Interfaces
{
    public interface ICartService
    {
        CartDetailsVm ViewCart(string applicationUserId);
        int CreateCart(string applicationUserId);
        void AddItemToCart(int boardGameId, int cartId);
        void DeleteCartItemFromCart(int cartItemId);
        void IncrementCartItemQuantity(int cartId, int cartItemId);
        void DecrementCartItemQuantity(int cartId, int cartItemId);
    }
}
