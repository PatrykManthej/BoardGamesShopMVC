using BoardGamesShopMVC.Domain.Models;

namespace BoardGamesShopMVC.Domain.Interfaces
{
    public interface IPublisherRepository
    {
        int AddPublisher(Publisher publisher);
        void DeletePublisher(int publisherId);
        IQueryable<Publisher> GetAllPublishers();
        Publisher GetPublisherById(int publisherId);
        IQueryable<BoardGame> GetAllBoardGamesByPublisherId(int id);
    }
}