namespace BoardGamesShopMVC.Web.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public decimal TotalPrice { get; set; }

        public ICollection<CartItem> CartItems { get; set; }
    }
}
