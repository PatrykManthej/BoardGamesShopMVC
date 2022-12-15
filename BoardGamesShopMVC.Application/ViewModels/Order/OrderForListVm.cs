namespace BoardGamesShopMVC.Application.ViewModels.Order
{
    public class OrderForListVm
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string OrderStatus { get; set; }
        public string PaymentStatus { get; set; }
        public DateTime OrderDate { get; set; }
        public string UserEmail { get; set;}
    }
}
