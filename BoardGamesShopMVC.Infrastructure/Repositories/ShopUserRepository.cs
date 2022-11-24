using BoardGamesShopMVC.Domain.Interfaces;
using BoardGamesShopMVC.Domain.Model;

namespace BoardGamesShopMVC.Infrastructure.Repositories
{
    public class ShopUserRepository : IShopUserRepository
    {
        private readonly Context _context;
        public ShopUserRepository(Context context)
        {
            _context = context;
        }

        public int AddShopUser(ShopUser shopUser)
        {
            _context.ShopUsers.Add(shopUser);
            _context.SaveChanges();
            return shopUser.Id;
        }

        public void DeleteShopUser(int shopUserId)
        {
            var shopUser = _context.ShopUsers.Find(shopUserId);
            if (shopUser != null)
            {
                _context.ShopUsers.Remove(shopUser);
                _context.SaveChanges();
            }
        }

        public ShopUser GetShopUserById(int shopUserId)
        {
            var shopUser = _context.ShopUsers.FirstOrDefault(b => b.Id == shopUserId);
            return shopUser;
        }

        public ShopUser GetShopUserByIdentityUserId(string identityUserId)
        {
            var shopUser = _context.ShopUsers.FirstOrDefault(s => s.IdentityUserId == identityUserId);
            return shopUser;
        }


        public IQueryable<ShopUser> GetAllShopUsers()
        {
            var shopUsers = _context.ShopUsers;
            return shopUsers;
        }
    }
}
