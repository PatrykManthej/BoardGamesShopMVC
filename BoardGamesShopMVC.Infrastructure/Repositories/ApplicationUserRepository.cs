using BoardGamesShopMVC.Domain.Interfaces;
using BoardGamesShopMVC.Domain.Model;

namespace BoardGamesShopMVC.Infrastructure.Repositories
{
    public class ApplicationUserRepository : IApplicationUserRepository
    {
        private readonly Context _context;
        public ApplicationUserRepository(Context context)
        {
            _context = context;
        }

        public string AddApplicationUser(ApplicationUser applicationUser)
        {
            _context.ApplicationUsers.Add(applicationUser);
            _context.SaveChanges();
            return applicationUser.Id;
        }

        public void DeleteApplicationUser(string ApplicationUserId)
        {
            var ApplicationUser = _context.ApplicationUsers.Find(ApplicationUserId);
            if (ApplicationUser != null)
            {
                _context.ApplicationUsers.Remove(ApplicationUser);
                _context.SaveChanges();
            }
        }

        public ApplicationUser GetApplicationUserById(string ApplicationUserId)
        {
            var ApplicationUser = _context.ApplicationUsers.FirstOrDefault(b => b.Id == ApplicationUserId);
            return ApplicationUser;
        }


        public IQueryable<ApplicationUser> GetAllApplicationUsers()
        {
            var ApplicationUsers = _context.ApplicationUsers;
            return ApplicationUsers;
        }
    }
}
