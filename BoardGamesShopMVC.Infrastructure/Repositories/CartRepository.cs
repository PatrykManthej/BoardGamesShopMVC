using BoardGamesShopMVC.Domain.Interfaces;
using BoardGamesShopMVC.Domain.Models;
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
                .Include(c=>c.CartItems)
                .ThenInclude(ci=>ci.BoardGame)
                .FirstOrDefault(b => b.Id == cartId);
            return cart;
        }

        public IQueryable<Cart> GetAllCarts()
        {
            var carts = _context.Carts;
            return carts;
        }
        public void AddItemToCart(int cartId, int boardGameId)
        {
            var cart = _context.Carts
                .Include(c=>c.CartItems)
                .FirstOrDefault(c=>c.Id == cartId);
            if (cart != null)
            {
                if(cart.CartItems == null)
                {
                    cart.CartItems = new List<CartItem>();
                }
                var cartItem = cart.CartItems.FirstOrDefault(c=>c.BoardGameId == boardGameId);
                if(cartItem == null)
                {
                    var newCartItem = new CartItem()
                    {
                        Quantity = 1,
                        BoardGameId = boardGameId,
                        CartId = cartId
                    };
                    _context.CartItems.Add(newCartItem);
                    _context.SaveChanges();
                }
                else
                {
                    cartItem.Quantity++;
                    _context.SaveChanges();
                }
            }
        }

        public void DeleteItemFromCart(int cartId, int cartItemId)
        {
            var cart = _context.Carts.Find(cartId);
            if (cart != null)
            {
                var cartItem = _context.CartItems
                    .FirstOrDefault(i => i.Id == cartItemId);

                if (cartItem != null)
                {
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
                    //cart.TotalAmount -= cartItem.TotalPrice;
                    cartItem.Quantity = quantity;
                    //cart.TotalAmount += cartItem.TotalPrice;
                    _context.SaveChanges();
                }
            }
        }
        public void CalculateTotalAmount(int cartId)
        {
            var cart = _context.Carts
                .Include(c => c.CartItems)
                .ThenInclude(ci => ci.BoardGame)
                .FirstOrDefault(b => b.Id == cartId);
            decimal total = 0;
            foreach (var item in cart.CartItems)
            {
                total += item.BoardGame.Price * item.Quantity;
            }
            cart.TotalAmount = total;
           // _context.Attach(cart);
            //_context.Entry(cart).Property("TotalAmount").IsModified = true;
            _context.SaveChanges();
        }
        public void IncrementCartItemQuantity(int cartId, int cartItemId)
        {
            var cart = _context.Carts.Find(cartId);
            if (cart != null)
            {
                var cartItem = _context.CartItems
                  .FirstOrDefault(i => i.Id == cartItemId);

                if (cartItem != null)
                {
                    cartItem.Quantity++;
                    _context.SaveChanges();
                }
            }
        }
        public void DecrementCartItemQuantity(int cartId, int cartItemId)
        {
            var cart = _context.Carts.Find(cartId);
            if (cart != null)
            {
                var cartItem = _context.CartItems
                  .FirstOrDefault(i => i.Id == cartItemId);

                if (cartItem != null)
                {
                    cartItem.Quantity--;
                    if(cartItem.Quantity == 0)
                    {
                        _context.Remove(cartItem);
                    }
                    _context.SaveChanges();
                }
            }
        }
    }
}
