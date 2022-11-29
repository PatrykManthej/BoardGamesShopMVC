using BoardGamesShopMVC.Domain.Model;

namespace BoardGamesShopMVC.Domain.Interfaces
{
    public interface IShopUserRepository
    {
        int AddShopUser(ShopUser shopUser);
        void DeleteShopUser(int shopUserId);
        IQueryable<ShopUser> GetAllShopUsers();
        ShopUser GetShopUserById(int shopUserId);
        ShopUser GetShopUserByIdentityUserId(string identityUserId);
    }
}