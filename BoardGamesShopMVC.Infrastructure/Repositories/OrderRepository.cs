﻿using BoardGamesShopMVC.Domain.Interfaces;
using BoardGamesShopMVC.Domain.Models;

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
            var order = _context.Orders.FirstOrDefault(b => b.Id == orderId);
            return order;
        }

        public IQueryable<Order> GetAllOrders()
        {
            var orders = _context.Orders;
            return orders;
        }
        public IQueryable<Order> GetAllCustomerOrders(int customerId)
        {
            var orders = _context.Orders.Where(o => o.CustomerId == customerId);
            return orders;
        }
    }
}
