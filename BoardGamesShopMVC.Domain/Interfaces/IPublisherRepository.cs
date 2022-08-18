using BoardGamesShopMVC.Domain.Models;

namespace BoardGamesShopMVC.Domain.Interfaces
{
    public interface IPublisherRepository
    {
        int AddPublisher(Publisher publisher);
        void DeletePublisher(int publisherId);
        void UpdatePublisher(Publisher publisher);
        IQueryable<Publisher> GetAllPublishers();
        Publisher GetPublisherById(int publisherId);
        IQueryable<BoardGame> GetAllBoardGamesByPublisherId(int id);
    }
}