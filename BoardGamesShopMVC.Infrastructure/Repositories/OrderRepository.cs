using BoardGamesShopMVC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGamesShopMVC.Infrastructure.Repositories
{
    public class OrderRepository
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
            var order = _context.Orders.FirstOrDefault(b => b.Id == orderId);
            return order;
        }

        public IQueryable<Order> GetAllOrders()
        {
            var orders = _context.Orders;
            return orders;
        }
    }
}
