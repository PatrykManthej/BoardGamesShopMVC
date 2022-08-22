using BoardGamesShopMVC.Application.ViewModels.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGamesShopMVC.Application.Interfaces
{
    public interface ICartService
    {
        CartDetailsVm ViewCart();
        void AddItemToCart(int boardGameId, int cartId);
        void DeleteCartItemFromCart(int cartItemId);
    }
}
