namespace BoardGamesShopMVC.Web.Models
{
    public class Stock
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public BoardGame BoardGame { get; set; }
        public int BoardGameId { get; set; }
    }
}
