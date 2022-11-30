namespace BoardGamesShopMVC.Domain.Model
{
    public class Address
    {
        public int Id { get; set; }
        public string? Street { get; set; }
        public string BuildingNumber { get; set; }
        public int? FlatNumber { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
        public string ApplicationUserId { get; set; }
    }
}