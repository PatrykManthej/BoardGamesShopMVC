using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGamesShopMVC.Application.ViewModels.ShopUser
{
    public class ShopUserWithAddressVm
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public AddressVm Address { get; set; }
    }

    public class AddressVm
    {
        public int Id { get; set; }
        public string? Street { get; set; }
        public string? BuildingNumber { get; set; }
        public int? FlatNumber { get; set; }
        public string? ZipCode { get; set; }
        public string? City { get; set; }
    }
}
