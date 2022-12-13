using BoardGamesShopMVC.Domain.Model;

namespace BoardGamesShopMVC.Domain.Interfaces
{
    public interface IOrderRepository
    {
        int AddOrder(Order order);
        void DeleteOrder(int orderId);
        IQueryable<Order> GetAllApplicationUserOrders(string ApplicationUserId);
        IQueryable<Order> GetAllOrders();
        Order GetOrderById(int orderId);
        void UpdateOrder(Order order);
    }
}