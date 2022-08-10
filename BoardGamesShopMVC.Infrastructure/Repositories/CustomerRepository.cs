using BoardGamesShopMVC.Domain.Interfaces;
using BoardGamesShopMVC.Domain.Model.Customer;

namespace BoardGamesShopMVC.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly Context _context;
        public CustomerRepository(Context context)
        {
            _context = context;
        }

        public int AddCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return customer.Id;
        }

        public void DeleteCustomer(int customerId)
        {
            var customer = _context.Customers.Find(customerId);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                _context.SaveChanges();
            }
        }

        public Customer GetCustomerById(int customerId)
        {
            var customer = _context.Customers.FirstOrDefault(b => b.Id == customerId);
            return customer;
        }

        public IQueryable<Customer> GetAllCustomers()
        {
            var customers = _context.Customers;
            return customers;
        }
    }
}
