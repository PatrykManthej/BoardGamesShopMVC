using Microsoft.AspNetCore.Identity;

namespace BoardGamesShopMVC.Domain.Model
{
    public class ApplicationUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Street { get; set; }
        public string? BuildingNumber { get; set; }
        public int? FlatNumber { get; set; }
        public string? ZipCode { get; set; }
        public string? City { get; set; }

        public Cart Cart { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<Address> Addresses { get; set; }
        public ICollection<Recipient> Recipients { get; set; }
    }
}
