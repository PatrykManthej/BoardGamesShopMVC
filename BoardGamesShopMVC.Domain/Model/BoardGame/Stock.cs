using BoardGamesShopMVC.Domain.Model.Common;

namespace BoardGamesShopMVC.Domain.Model
{
    public class Stock : AuditableEntity
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public BoardGame BoardGame { get; set; }
    }
}
