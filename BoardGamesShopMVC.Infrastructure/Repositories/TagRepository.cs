using BoardGamesShopMVC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGamesShopMVC.Infrastructure.Repositories
{
    public class TagRepository
    {
        private readonly Context _context;
        public TagRepository(Context context)
        {
            _context = context;
        }
        public int AddTag(Tag tag)
        {
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
