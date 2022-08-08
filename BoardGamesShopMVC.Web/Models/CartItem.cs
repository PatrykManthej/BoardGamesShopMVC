namespace BoardGamesShopMVC.Web.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public int Quantity { get; set; }

        public BoardGame BoardGame { get; set; }
        public int BoardGameId { get; set; }
        public Cart Cart { get; set; }
        public int CartId { get; set; }
    }
}
