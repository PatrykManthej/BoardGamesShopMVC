namespace BoardGamesShopMVC.Domain.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }

        public BoardGame BoardGame { get; set; }
        public int BoardGameId { get; set; }
        public Order Order { get; set; }
        public int OrderId { get; set; }
    }
}
