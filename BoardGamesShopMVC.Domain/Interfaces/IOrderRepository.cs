using BoardGamesShopMVC.Domain.Model;

namespace BoardGamesShopMVC.Domain.Interfaces
{
    public interface IOrderRepository
    {
        int AddOrder(Order order);
        void DeleteOrder(int orderId);
        IQueryable<Order> GetAllCustomerOrders(int customerId);
        IQueryable<Order> GetAllOrders();
        Order GetOrderById(int orderId);
    }
}