using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGamesShopMVC.Application.ViewModels.Cart
{
    public class CartDetailsVm
    {
        public int Id { get; set; }
        public decimal TotalAmount { get; set; }

        //public ICollection<CartItem> CartItems { get; set; }
    }
}
