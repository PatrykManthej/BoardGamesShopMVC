using BoardGamesShopMVC.Application.ViewModels.Cart;
using Stripe.Checkout;

namespace BoardGamesShopMVC.Application.Interfaces
{
    public interface IPaymentService
    {
        public Session CreateStripeSession(CartSummaryVm cartVm, int orderId);
    }
}
