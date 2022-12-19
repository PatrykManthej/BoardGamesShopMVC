namespace BoardGamesShopMVC.Application.ViewModels.Order
{
	public class OrderItemVm
	{
		public int Id { get; set; }
		public int Quantity { get; set; }
		public string Name { get; set; }
		public decimal UnitPrice { get; set; }
		public decimal TotalPrice { get; set; }
	}
}
