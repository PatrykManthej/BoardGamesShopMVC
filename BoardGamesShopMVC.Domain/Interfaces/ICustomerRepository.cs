using BoardGamesShopMVC.Domain.Model.Customer;

namespace BoardGamesShopMVC.Domain.Interfaces
{
    public interface ICustomerRepository
    {
        int AddCustomer(Customer customer);
        void DeleteCustomer(int customerId);
        IQueryable<Customer> GetAllCustomers();
        Customer GetCustomerById(int customerId);
    }
}