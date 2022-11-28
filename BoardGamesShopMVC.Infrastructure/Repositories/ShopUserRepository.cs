using BoardGamesShopMVC.Domain.Interfaces;
using BoardGamesShopMVC.Domain.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

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
        public ShopUser GetShopUserWithAddressByIdentityUserId(string identityUserId)
        {
            var shopUser = _context.ShopUsers.Include(u=>u.Addresses)
                .FirstOrDefault(s => s.IdentityUserId == identityUserId);
            return shopUser;
        }
        public IQueryable<ShopUser> GetAllShopUsers()
        {
            var shopUsers = _context.ShopUsers;
            return shopUsers;
        }

        public void UpdateShopUser(ShopUser shopUser)
        {
            _context.Attach(shopUser);
            _context.Entry(shopUser).Property("FirstName").IsModified=true;
            _context.Entry(shopUser).Property("LastName").IsModified = true;
            _context.Entry(shopUser).Property("Email").IsModified=true;
            _context.Entry(shopUser).Property("PhoneNumber").IsModified=true;
            _context.Entry(shopUser).Collection("Addresses").IsModified = true;
            foreach (var address in shopUser.Addresses)
            {
                _context.Entry(address).Property("Street").IsModified = true;
                _context.Entry(address).Property("BuildingNumber").IsModified = true;
                _context.Entry(address).Property("FlatNumber").IsModified = true;
                _context.Entry(address).Property("ZipCode").IsModified = true;
                _context.Entry(address).Property("City").IsModified = true;
            }
            _context.SaveChanges();
        }
    }
}
