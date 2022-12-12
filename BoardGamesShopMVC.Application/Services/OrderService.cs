using AutoMapper;
using BoardGamesShopMVC.Application.Interfaces;
using BoardGamesShopMVC.Application.ViewModels.Cart;
using BoardGamesShopMVC.Domain.Enums;
using BoardGamesShopMVC.Domain.Interfaces;
using BoardGamesShopMVC.Domain.Model;

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
        public int CreateOrder(CartSummaryVm cartVm, string userId)
        {
            var order = _mapper.Map<Order>(cartVm);
            order.ApplicationUserId = userId;
            order.Status = OrderStatus.Pending.ToString();
            order.OrderDate = DateTime.Now;
            var orderId = _orderRepository.AddOrder(order);
            return orderId;
        }
    }
}
