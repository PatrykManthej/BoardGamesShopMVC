namespace BoardGamesShopMVC.Domain.Model
{
    public class BoardGameCategory
    {
        public BoardGame BoardGame { get; set; }
        public int BoardGamesId { get; set; }
        public Category Category { get; set; }
        public int CategoriesId { get; set; }
    }
}
