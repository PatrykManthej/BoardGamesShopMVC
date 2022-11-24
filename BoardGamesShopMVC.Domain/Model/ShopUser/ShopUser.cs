namespace BoardGamesShopMVC.Domain.Model
{
    public class ShopUser
    {
        public int Id { get; set; }
        public string IdentityUserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }

        public Cart Cart { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<Address> Addresses { get; set; }
        public ICollection<Recipient> Recipients { get; set; }
    }
}
