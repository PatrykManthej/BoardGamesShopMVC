namespace BoardGamesShopMVC.Domain.Model
{
    public class Order
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }

        public ShopUser ShopUser { get; set; }
        public int ShopUserId { get; set; }
        public ICollection<OrderItem> Items { get; set; }
    }
}
