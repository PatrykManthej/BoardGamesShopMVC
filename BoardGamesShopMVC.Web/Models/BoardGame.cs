namespace BoardGamesShopMVC.Web.Models
{
    public class BoardGame
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Category> Categories { get; set; }
        public int Availability { get; set; }
        public List<Tag> Tags { get; set; }
        public string AverageTimeOfPlay { get; set; }
        public int RecommendedMinimumAge { get; set; }
        public int MinNumeberOfPlayers { get; set; }
        public int MaxNumeberOfPlayers { get; set; }
        public string LanguageVersion { get; set; }
        public string Publisher { get; set; }
        public int PublishedYear { get; set; }
    }
}
