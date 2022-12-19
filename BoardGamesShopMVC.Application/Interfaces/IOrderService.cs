using BoardGamesShopMVC.Application.ViewModels.Cart;
using BoardGamesShopMVC.Application.ViewModels.Order;
using BoardGamesShopMVC.Domain.Enums;

namespace BoardGamesShopMVC.Application.Interfaces
{
    public interface IOrderService
    {
        ListOrderForListVm GetAllOrders();
        int CreateOrder(CartSummaryVm cartVm, string userId);
        OrderDetailsVm GetOrderById(int orderId);
        void UpdateOrderStripePaymentSessionId(int orderId, string sessionId);
        void ConfirmOrder(int orderId);
        public void UpdateOrderStatus(int orderId, OrderStatus orderStatus, PaymentStatus? paymentStatus = null);

    }
}
