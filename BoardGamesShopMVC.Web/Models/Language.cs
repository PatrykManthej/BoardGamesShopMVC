namespace BoardGamesShopMVC.Web.Models
{
    public class Language
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<BoardGame> BoardGames { get; set; }
    }
}
