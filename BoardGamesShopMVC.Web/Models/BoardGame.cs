namespace BoardGamesShopMVC.Web.Models
{
    public class BoardGame
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string AverageTimeOfPlay { get; set; }
        public int RecommendedMinimumAge { get; set; }
        public int MinNumeberOfPlayers { get; set; }
        public int MaxNumeberOfPlayers { get; set; }
        public int PublishedYear { get; set; }
        public decimal Price { get; set; }

        public Language LanguageVersion { get; set; }
        public int LanguageId { get; set; }
        public Publisher Publisher { get; set; }
        public int PublisherId { get; set; }
        public Stock Stock { get; set; }
        public int StockId { get; set; }
        public ICollection<Category> Categories { get; set; }
        public ICollection<Tag> Tags { get; set; }
    }
}
