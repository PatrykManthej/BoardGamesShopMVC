namespace BoardGamesShopMVC.Domain.Model.Customer
{
    public class Address
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string BuildingNumber { get; set; }
        public int FlatNumber { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
    }
}