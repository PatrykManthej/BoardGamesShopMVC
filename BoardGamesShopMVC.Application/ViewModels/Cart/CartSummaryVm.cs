using BoardGamesShopMVC.Application.ViewModels.ApplicationUser;

namespace BoardGamesShopMVC.Application.ViewModels.Cart
{
    public class CartSummaryVm
    {
        public int Id { get; set; }
        public ApplicationUserVm ApplicationUserVm { get; set; }
        public decimal TotalAmount { get; set; }
        public List<CartItemVm> CartItems { get; set; }
    }
}
