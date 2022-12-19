using AutoMapper;
using BoardGamesShopMVC.Application.Interfaces;
using BoardGamesShopMVC.Application.ViewModels.Cart;
using BoardGamesShopMVC.Application.ViewModels.Order;
using BoardGamesShopMVC.Domain.Enums;
using BoardGamesShopMVC.Domain.Interfaces;
using BoardGamesShopMVC.Domain.Model;
using Stripe.Checkout;

namespace BoardGamesShopMVC.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public ListOrderForListVm GetAllOrders()
        {
            var orders = _orderRepository.GetAllOrders();
            var ordersVm = _mapper.ProjectTo<OrderForListVm>(orders).ToList();
            var listOrders = new ListOrderForListVm
            {
                Orders = ordersVm
            };
            return listOrders;
        }

        public int CreateOrder(CartSummaryVm cartVm, string userId)
        {
            var order = _mapper.Map<Order>(cartVm);
            order.ApplicationUserId = userId;
            order.OrderStatus = OrderStatus.Pending.ToString();
            order.PaymentStatus = PaymentStatus.Pending.ToString();
            order.OrderDate = DateTime.Now;
            var orderId = _orderRepository.AddOrder(order);
            return orderId;
        }

        public OrderDetailsVm GetOrderById(int orderId)
        {
            var order = _orderRepository.GetOrderById(orderId);
            var orderVm = _mapper.Map<OrderDetailsVm>(order);
            return orderVm;
        }

        public void UpdateOrderStripePaymentSessionId(int orderId, string sessionId)
        {
            var order = _orderRepository.GetOrderById(orderId);
            order.SessionId = sessionId;
            _orderRepository.UpdateOrder(order);
        }

        public void ConfirmOrder(int orderId)
        {
            var order = _orderRepository.GetOrderById(orderId);
            var service = new SessionService();
            Session session = service.Get(order.SessionId);

            if (session.PaymentStatus.ToLower() == "paid")
            {
               UpdateOrderStatus(orderId, OrderStatus.Approved, PaymentStatus.Approved);
            }

        }

        private void UpdateOrderStatus(int orderId, OrderStatus orderStatus, PaymentStatus paymentStatus)
        {
            var order = _orderRepository.GetOrderById(orderId);
            order.OrderStatus = orderStatus.ToString();
            order.PaymentStatus = paymentStatus.ToString();
            _orderRepository.UpdateOrder(order);
        }
    }
}