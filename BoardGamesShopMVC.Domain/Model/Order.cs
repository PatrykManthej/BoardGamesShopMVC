using BoardGamesShopMVC.Domain.Model.Customer;

namespace BoardGamesShopMVC.Domain.Models
{
    public class Order
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }

        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
        public ICollection<OrderItem> Items { get; set; }
    }
}
