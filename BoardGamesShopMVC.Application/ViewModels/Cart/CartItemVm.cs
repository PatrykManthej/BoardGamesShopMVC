namespace BoardGamesShopMVC.Application.ViewModels.Cart
{
    public class CartItemVm
    {
        public int Id { get; set; }
        public int BoardGameId { get; set; }
        public int Quantity { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }
        public string ImageUrl { get; set; }
    }
}
