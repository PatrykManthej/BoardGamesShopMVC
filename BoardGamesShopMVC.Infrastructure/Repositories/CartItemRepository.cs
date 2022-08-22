using BoardGamesShopMVC.Domain.Interfaces;
using BoardGamesShopMVC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGamesShopMVC.Infrastructure.Repositories
{
    public class CartItemRepository : ICartItemRepository
    {
        private readonly Context _context;
        public CartItemRepository (Context context)
        {
            _context = context;
        }

        public CartItem CreateCartItem(int boardGameId)
        {
            var cartItem = new CartItem()
            {
                Quantity = 1,
                BoardGameId = boardGameId,
            };
            return cartItem;
        }

    }
}
