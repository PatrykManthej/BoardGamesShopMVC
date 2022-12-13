using BoardGamesShopMVC.Application.ViewModels.Cart;
using BoardGamesShopMVC.Application.ViewModels.Order;
using Stripe.Checkout;

namespace BoardGamesShopMVC.Application.Interfaces
{
    public interface IOrderService
    {
        int CreateOrder(CartSummaryVm cartVm, string userId);
        OrderVm GetOrderById(int orderId);
        void UpdateOrderStripePaymentSessionId(int orderId, string sessionId, string paymentIntentId);
        void ConfirmOrder(int orderId);
    }
}
