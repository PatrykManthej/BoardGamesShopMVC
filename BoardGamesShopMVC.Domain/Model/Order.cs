namespace BoardGamesShopMVC.Domain.Models
{
    public class Order
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }

        public ICollection<OrderItem> Items { get; set; }
    }
}
