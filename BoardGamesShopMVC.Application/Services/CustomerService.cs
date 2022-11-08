using BoardGamesShopMVC.Application.Interfaces;
using BoardGamesShopMVC.Domain.Interfaces;
using BoardGamesShopMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGamesShopMVC.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public int AddCustomerAfterConfirmEmail(string userId, string userMail)
        {
            Customer customer = new Customer() { UserId = userId };
            var createdCustomerId = _customerRepository.AddCustomer(customer);
            return createdCustomerId;
        }
    }
}
