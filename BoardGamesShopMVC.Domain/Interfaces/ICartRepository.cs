using BoardGamesShopMVC.Domain.Model;

namespace BoardGamesShopMVC.Domain.Interfaces
{
    public interface ICartRepository
    {
        int AddCart(Cart cart);
        void DeleteCart(int cartId);
        IQueryable<Cart> GetAllCarts();
        Cart GetCartById(int cartId);
        void UpdateCart(Cart cart);

        void UpdateCartItem(CartItem cartItem);
        void DeleteCartItem(int cartItemId);
        void AddCartItem(CartItem cartItem);
    }
}