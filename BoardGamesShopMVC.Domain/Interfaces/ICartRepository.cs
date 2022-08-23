using BoardGamesShopMVC.Domain.Models;

namespace BoardGamesShopMVC.Domain.Interfaces
{
    public interface ICartRepository
    {
        int AddCart(Cart cart);
        void AddItemToCart(int cartId, int boardGameId);
        void ChangeCartItemQuantity(int cartId, int cartItemId, int quantity);
        void DeleteCart(int cartId);
        void DeleteItemFromCart(int cartId, int cartItemId);
        IQueryable<Cart> GetAllCarts();
        Cart GetCartById(int cartId);
        void CalculateTotalAmount(int cartId);
        void IncrementCartItemQuantity(int cartId, int cartItemId);
        void DecrementCartItemQuantity(int cartId, int cartItemId);
    }
}