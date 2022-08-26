using BoardGamesShopMVC.Domain.Interfaces;
using BoardGamesShopMVC.Domain.Model;

namespace BoardGamesShopMVC.Infrastructure.Repositories
{
    public class PublisherRepository : IPublisherRepository
    {
        private readonly Context _context;
        public PublisherRepository(Context context)
        {
            _context = context;
        }
        public int AddPublisher(Publisher publisher)
        {
            var existingPublisher = _context.Publishers.FirstOrDefault(p => p.Name.ToLower() == publisher.Name.ToLower());
            if(existingPublisher != null)
            {
                return existingPublisher.Id;
            }
            else
            {
                _context.Publishers.Add(publisher);
                _context.SaveChanges();
                return publisher.Id;
            }
        }
        public void UpdatePublisher(Publisher publisher)
        {
            _context.Attach(publisher);
            _context.Entry(publisher).Property("Name").IsModified = true;
            _context.SaveChanges();
        }

        public void DeletePublisher(int publisherId)
        {
            var publisher = _context.Publishers.Find(publisherId);
            if (publisher != null)
            {
                _context.Publishers.Remove(publisher);
                _context.SaveChanges();
            }
        }

        public Publisher GetPublisherById(int publisherId)
        {
            var publisher = _context.Publishers.FirstOrDefault(b => b.Id == publisherId);
            return publisher;
        }

        public IQueryable<Publisher> GetAllPublishers()
        {
            var publishers = _context.Publishers;
            return publishers;
        }

        public IQueryable<BoardGame> GetAllBoardGamesByPublisherId(int id)
        {
            var boardGames = _context.BoardGames
                .Where(b => b.PublisherId == id);
            return boardGames;
        }

    }
}
