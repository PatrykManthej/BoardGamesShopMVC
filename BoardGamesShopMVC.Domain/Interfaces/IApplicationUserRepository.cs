using BoardGamesShopMVC.Domain.Model;

namespace BoardGamesShopMVC.Domain.Interfaces
{
    public interface IApplicationUserRepository
    {
        string AddApplicationUser(ApplicationUser applicationUser);
        void DeleteApplicationUser(string ApplicationUserId);
        IQueryable<ApplicationUser> GetAllApplicationUsers();
        ApplicationUser GetApplicationUserById(string ApplicationUserId);
    }
}