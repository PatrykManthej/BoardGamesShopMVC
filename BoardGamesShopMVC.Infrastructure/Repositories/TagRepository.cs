using BoardGamesShopMVC.Domain.Interfaces;
using BoardGamesShopMVC.Domain.Models;

namespace BoardGamesShopMVC.Infrastructure.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly Context _context;
        public TagRepository(Context context)
        {
            _context = context;
        }
        public int AddTag(Tag tag)
        {
            var existingTag = _context.Tags.FirstOrDefault(t => t.Name == tag.Name);
            if (existingTag != null)
            {
                return existingTag.Id;
            }
            _context.Tags.Add(tag);
            _context.SaveChanges();
            return tag.Id;
        }

        public void DeleteTag(int tagId)
        {
            var tag = _context.Tags.Find(tagId);
            if (tag != null)
            {
                _context.Tags.Remove(tag);
                _context.SaveChanges();
            }
        }

        public Tag GetTagById(int tagId)
        {
            var tag = _context.Tags.FirstOrDefault(b => b.Id == tagId);
            return tag;
        }

        public IQueryable<Tag> GetAllTags()
        {
            var tags = _context.Tags;
            return tags;
        }
    }
}
