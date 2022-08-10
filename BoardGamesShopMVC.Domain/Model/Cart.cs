using BoardGamesShopMVC.Domain.Model.Customer;

namespace BoardGamesShopMVC.Domain.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public decimal TotalPrice { get; set; }

        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
        public ICollection<CartItem> CartItems { get; set; }
    }
}
