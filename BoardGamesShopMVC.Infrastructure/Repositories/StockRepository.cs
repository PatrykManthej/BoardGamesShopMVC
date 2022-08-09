using BoardGamesShopMVC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGamesShopMVC.Infrastructure.Repositories
{
    public class StockRepository
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
            var stock = _context.Stocks.FirstOrDefault(b => b.Id == stockId);
            return stock;
        }

        public IQueryable<Stock> GetAllStocks()
        {
            var stocks = _context.Stocks;
            return stocks;
        }
    }
}
