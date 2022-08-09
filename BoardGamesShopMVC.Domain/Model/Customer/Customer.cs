using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGamesShopMVC.Domain.Model.Customer
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<Address> Addresses { get; set; }
        public ICollection<ContactDetail> ContactDetails { get; set; }
    }
}
