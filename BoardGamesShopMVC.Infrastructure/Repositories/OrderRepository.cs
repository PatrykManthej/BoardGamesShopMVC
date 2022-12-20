using BoardGamesShopMVC.Domain.Interfaces;
using BoardGamesShopMVC.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace BoardGamesShopMVC.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly Context _context;
        public OrderRepository(Context context)
        {
            _context = context;
        }

        public int AddOrder(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
            return order.Id;
        }

        public void DeleteOrder(int orderId)
        {
            var order = _context.Orders.Find(orderId);
            if (order != null)
            {
                _context.Orders.Remove(order);
                _context.SaveChanges();
            }
        }

        public Order GetOrderById(int orderId)
        {
            var order = _context.Orders
                .Include(x=>x.OrderRecipient)
                .Include(x=>x.ApplicationUser)
                .Include(x=>x.Items)
                .ThenInclude(x=>x.BoardGame)
                .FirstOrDefault(b => b.Id == orderId);
            return order;
        }

        public IQueryable<Order> GetAllOrders()
        {
            var orders = _context.Orders;
            return orders;
        }

        public IQueryable<Order> GetAllApplicationUserOrders(string applicationUserId)
        {
            var orders = _context.Orders.Where(o => o.ApplicationUserId == applicationUserId);
            return orders;
        }

        public void UpdateOrder(Order order)
        {
            var orderRecipient = order.OrderRecipient;

            _context.Attach(order);
            _context.Entry(order).Property("SessionId").IsModified=true;
            _context.Entry(order).Property("OrderStatus").IsModified=true;
            _context.Entry(order).Property("PaymentStatus").IsModified=true;
            _context.Entry(order).Property("ShippingDate").IsModified=true;
            _context.Entry(order).Property("TrackingNumber").IsModified=true;
            _context.Entry(order).Property("Carrier").IsModified=true;

            _context.Entry(orderRecipient).Property("Email").IsModified=true;
            _context.Entry(orderRecipient).Property("FirstName").IsModified=true;
            _context.Entry(orderRecipient).Property("LastName").IsModified=true;
            _context.Entry(orderRecipient).Property("PhoneNumber").IsModified=true;
            _context.Entry(orderRecipient).Property("Street").IsModified=true;
            _context.Entry(orderRecipient).Property("BuildingNumber").IsModified=true;
            _context.Entry(orderRecipient).Property("FlatNumber").IsModified=true;
            _context.Entry(orderRecipient).Property("ZipCode").IsModified=true;
            _context.Entry(orderRecipient).Property("City").IsModified=true;
           
            _context.SaveChanges();
        }
    }
}
