namespace BoardGamesShopMVC.Domain.Model
{
    public class Order
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string? OrderStatus { get; set; }
        public string? PaymentStatus { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ShippingDate { get; set; }
        public string? SessionId { get; set; }

        public OrderRecipient OrderRecipient { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public string ApplicationUserId { get; set; }
        public ICollection<OrderItem> Items { get; set; }
    }
}
