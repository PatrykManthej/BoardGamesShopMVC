namespace BoardGamesShopMVC.Domain.Model
{
    public class Order
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
        public string ApplicationUserId { get; set; }
        public ICollection<OrderItem> Items { get; set; }
    }
}
