using BoardGamesShopMVC.Domain.Interfaces;
using BoardGamesShopMVC.Domain.Models;

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
            _context.Publishers.Add(publisher);
            _context.SaveChanges();
            return publisher.Id;
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
    }
}
