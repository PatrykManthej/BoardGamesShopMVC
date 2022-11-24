namespace BoardGamesShopMVC.Domain.Model
{
    public class Recipient
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }

        public ShopUser ShopUser { get; set; }
        public int ShopUserId { get; set; }
    }
}
