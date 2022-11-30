using BoardGamesShopMVC.Application.ViewModels.Cart;

namespace BoardGamesShopMVC.Application.Interfaces
{
    public interface ICartService
    {
        CartDetailsVm ViewCart(string ApplicationUserId);
        void CreateCart(string ApplicationUserId);
        void AddItemToCart(int boardGameId, int cartId);
        void DeleteCartItemFromCart(int cartItemId);
        void IncrementCartItemQuantity(int cartId, int cartItemId);
        void DecrementCartItemQuantity(int cartId, int cartItemId);
    }
}
