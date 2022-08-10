using BoardGamesShopMVC.Domain.Models;

namespace BoardGamesShopMVC.Domain.Interfaces
{
    public interface ITagRepository
    {
        int AddTag(Tag tag);
        void DeleteTag(int tagId);
        IQueryable<Tag> GetAllTags();
        Tag GetTagById(int tagId);
    }
}