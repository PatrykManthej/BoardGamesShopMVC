using BoardGamesShopMVC.Domain.Interfaces;
using BoardGamesShopMVC.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace BoardGamesShopMVC.Infrastructure.Repositories
{
    public class StockRepository : IStockRepository
    {
        private readonly Context _context;
        public StockRepository(Context context)
        {
            _context = context;
        }

        public int AddStock(Stock stock)
        {
            _context.Stocks.Add(stock);
            _context.SaveChanges();
            return stock.Id;
        }

        public void DeleteStock(int stockId)
        {
            var stock = _context.Stocks.Find(stockId);
            if (stock != null)
            {
                _context.Stocks.Remove(stock);
                _context.SaveChanges();
            }
        }

        public Stock GetStockById(int stockId)
        {
            var stock = _context.Stocks
                .Where(b => b.StatusId == 1)
                .FirstOrDefault(b => b.Id == stockId);
            return stock;
        }

        public IQueryable<Stock> GetAllStocks()
        {
            var stocks = _context.Stocks
                .Where(b => b.StatusId == 1);
            return stocks;
        }

        public Stock GetStockByBoardGameId(int boardGameId)
        {
            var stock = _context.Stocks
                .Where(b => b.StatusId == 1)
                .Include(s => s.BoardGame)
                .FirstOrDefault(s => s.BoardGame.Id == boardGameId);
            return stock;
        }

        public void UpdateStock(Stock stock)
        {
            _context.Attach(stock);
            _context.Entry(stock).Property("Quantity").IsModified = true;
            _context.SaveChanges();
        }
    }
}
