using BoardGamesShopMVC.Domain.Models;

namespace BoardGamesShopMVC.Domain.Interfaces
{
    public interface IStockRepository
    {
        int AddStock(Stock stock);
        void DeleteStock(int stockId);
        IQueryable<Stock> GetAllStocks();
        Stock GetStockById(int stockId);
    }
}