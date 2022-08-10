namespace BoardGamesShopMVC.Domain.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }

        public BoardGame BoardGame { get; set; }
        public int BoardGameId { get; set; }
        public Cart Cart { get; set; }
        public int CartId { get; set; }
    }
}
