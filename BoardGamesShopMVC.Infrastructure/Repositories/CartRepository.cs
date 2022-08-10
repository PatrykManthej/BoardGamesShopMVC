using BoardGamesShopMVC.Domain.Interfaces;
using BoardGamesShopMVC.Domain.Models;

namespace BoardGamesShopMVC.Infrastructure.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly Context _context;
        public CartRepository(Context context)
        {
            _context = context;
        }
        public int AddCart(Cart cart)
        {
            _context.Carts.Add(cart);
            _context.SaveChanges();
            return cart.Id;
        }

        public void DeleteCart(int cartId)
        {
            var cart = _context.Carts.Find(cartId);
            if (cart != null)
            {
                _context.Carts.Remove(cart);
                _context.SaveChanges();
            }
        }

        public Cart GetCartById(int cartId)
        {
            var cart = _context.Carts.FirstOrDefault(b => b.Id == cartId);
            return cart;
        }

        public IQueryable<Cart> GetAllCarts()
        {
            var carts = _context.Carts;
            return carts;
        }
        public void AddItemToCart(int cartId, CartItem cartItem)
        {
            var cart = _context.Carts.Find(cartId);
            if (cart != null)
            {
                cart.CartItems.Add(cartItem);
                cart.TotalAmount += cartItem.TotalPrice;
                _context.SaveChanges();
            }
        }
        public void DeleteItemFromCart(int cartId, int cartItemId)
        {
            var cart = _context.Carts.Find(cartId);
            if (cart != null)
            {
                var cartItem = cart.CartItems.FirstOrDefault(i => i.Id == cartItemId);
                if (cartItem != null)
                {
                    cart.TotalAmount -= cartItem.TotalPrice;
                    _context.CartItems.Remove(cartItem);
                    _context.SaveChanges();
                }
            }
        }
        public void ChangeCartItemQuantity(int cartId, int cartItemId, int quantity)
        {
            var cart = _context.Carts.Find(cartId);
            if (cart != null)
            {
                var cartItem = cart.CartItems.FirstOrDefault(i => i.Id == cartItemId);
                if (cartItem != null)
                {
                    cart.TotalAmount -= cartItem.TotalPrice;
                    cartItem.Quantity = quantity;
                    cart.TotalAmount += cartItem.TotalPrice;
                    _context.SaveChanges();
                }
            }

        }
    }
}
