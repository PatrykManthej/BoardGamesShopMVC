using BoardGamesShopMVC.Domain.Interfaces;
using BoardGamesShopMVC.Domain.Model;
using Microsoft.EntityFrameworkCore;

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
            var cart = _context.Carts
                .Include(c => c.CartItems)
                .ThenInclude(ci => ci.BoardGame)
                .FirstOrDefault(b => b.Id == cartId);
            return cart;
        }

        public IQueryable<Cart> GetAllCarts()
        {
            var carts = _context.Carts;
            return carts;
        }

        public void UpdateCart(Cart cart)
        {
            _context.Attach(cart);
            _context.Entry(cart).Property("TotalAmount").IsModified = true;
            _context.SaveChanges();
        }

        public void UpdateCartItem(CartItem cartItem)
        {
            _context.Attach(cartItem);
            _context.Entry(cartItem).Property("Quantity").IsModified = true;
            _context.SaveChanges();
        }

        public void DeleteCartItem(int cartItemId)
        {
            var cartItem = _context.CartItems.Find(cartItemId);
            if(cartItem != null)
            {
                _context.CartItems.Remove(cartItem);
                _context.SaveChanges();
            }
        }

        public void AddCartItem(CartItem cartItem)
        {
            _context.CartItems.Add(cartItem);
            _context.SaveChanges();
        }
    }
}
