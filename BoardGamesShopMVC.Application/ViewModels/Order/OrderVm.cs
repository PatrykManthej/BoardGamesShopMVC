using BoardGamesShopMVC.Domain.Model;

namespace BoardGamesShopMVC.Application.ViewModels.Order
{
    public class OrderVm
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string? OrderStatus { get; set; }
        public string? PaymentStatus { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ShippingDate { get; set; }
        public string? SessionId { get; set; }
        public string? PaymentIntentId { get; set; }

    }
}
