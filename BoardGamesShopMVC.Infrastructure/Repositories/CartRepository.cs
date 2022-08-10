using BoardGamesShopMVC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGamesShopMVC.Infrastructure.Repositories
{
    public class CartRepository
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
        public void AddCartItemToCart(int cartId, CartItem cartItem)
        {
            var cart = _context.Carts.Find(cartId);
            if(cart != null)
            {
                cart.CartItems.Add(cartItem);
                _context.SaveChanges();
            }
        }
    }
}
