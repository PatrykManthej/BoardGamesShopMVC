namespace BoardGamesShopMVC.Domain.Model
{
    public class Stock
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public BoardGame BoardGame { get; set; }
    }
}
