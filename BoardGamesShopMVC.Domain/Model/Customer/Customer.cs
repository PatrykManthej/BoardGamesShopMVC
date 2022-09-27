namespace BoardGamesShopMVC.Domain.Model
{
    public class Customer
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public Cart Cart { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<Address> Addresses { get; set; }
        public ICollection<ContactDetail> ContactDetails { get; set; }
    }
}
