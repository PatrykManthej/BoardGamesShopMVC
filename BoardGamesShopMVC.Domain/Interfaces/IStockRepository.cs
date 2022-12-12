using BoardGamesShopMVC.Domain.Model;

namespace BoardGamesShopMVC.Domain.Interfaces
{
    public interface IStockRepository
    {
        int AddStock(Stock stock);
        void DeleteStock(int stockId);
        IQueryable<Stock> GetAllStocks();
        Stock GetStockById(int stockId);
        Stock GetStockByBoardGameId(int boardGameId);
        void UpdateStock(Stock stock);
        void RemoveBoardGamesFromStock(Dictionary<int,int> boardGamesIdAndQuantity);
    }
}