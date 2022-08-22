using BoardGamesShopMVC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGamesShopMVC.Domain.Interfaces
{
    public interface ICartItemRepository
    {
        CartItem CreateCartItem(int boardGameId);
    }
}
