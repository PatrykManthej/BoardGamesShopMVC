using BoardGamesShopMVC.Application.ViewModels.ApplicationUser;

namespace BoardGamesShopMVC.Application.Interfaces
{
    public interface IApplicationUserService
    {
        string AddApplicationUserAfterConfirmEmail(string userId, string userMail);
        ApplicationUserVm GetApplicationUserById(string applicationUserId);
    }
}
