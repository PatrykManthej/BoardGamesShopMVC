namespace BoardGamesShopMVC.Web.Models
{
    public class Publisher
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<BoardGame> BoardGames { get; set; }
    }
}
