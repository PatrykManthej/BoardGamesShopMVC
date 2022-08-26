namespace BoardGamesShopMVC.Domain.Model
{
    public class Cart
    {
        public int Id { get; set; }
        public decimal TotalAmount { get; set; }

        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
        public ICollection<CartItem> CartItems { get; set; }
    }
}
