namespace BoardGamesShopMVC.Domain.Model
{
    public class OrderRecipient
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Street { get; set; }
        public string BuildingNumber { get; set; }
        public int FlatNumber { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }

        public Order Order { get; set; }
        public int OrderId { get; set; }
    }
}
