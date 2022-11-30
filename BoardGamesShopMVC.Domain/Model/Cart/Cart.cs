namespace BoardGamesShopMVC.Domain.Model
{
    public class Cart
    {
        public int Id { get; set; }
        public decimal TotalAmount { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
        public string ApplicationUserId { get; set; }
        public ICollection<CartItem> CartItems { get; set; }
    }
}
