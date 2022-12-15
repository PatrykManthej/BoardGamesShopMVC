using BoardGamesShopMVC.Application.ViewModels.Cart;
using BoardGamesShopMVC.Application.ViewModels.Order;
using Stripe.Checkout;

namespace BoardGamesShopMVC.Application.Interfaces
{
    public interface IOrderService
    {
        ListOrderForListVm GetAllOrders();
        int CreateOrder(CartSummaryVm cartVm, string userId);
        OrderDetailsVm GetOrderById(int orderId);
        void UpdateOrderStripePaymentSessionId(int orderId, string sessionId, string paymentIntentId);
        void ConfirmOrder(int orderId);
    }
}
