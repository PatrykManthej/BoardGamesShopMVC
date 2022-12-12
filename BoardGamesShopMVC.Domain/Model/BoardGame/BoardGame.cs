using BoardGamesShopMVC.Domain.Model.Common;

namespace BoardGamesShopMVC.Domain.Model
{
    public class BoardGame : AuditableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string AverageTimeOfPlay { get; set; }
        public int RecommendedMinimumAge { get; set; }
        public int MinNumberOfPlayers { get; set; }
        public int MaxNumberOfPlayers { get; set; }
        public int PublishedYear { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }

        public Language LanguageVersion { get; set; }
        public int LanguageId { get; set; }
        public Publisher Publisher { get; set; }
        public int PublisherId { get; set; }
        public Stock Stock { get; set; }
        public int StockId { get; set; }
        public ICollection<CartItem> CartItems { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
        public ICollection<Category> Categories { get; set; }
    }
}
