using BoardGamesShopMVC.Application.ViewModels.ShopUser;

namespace BoardGamesShopMVC.Application.Interfaces
{
    public interface IShopUserService
    {
        int AddShopUserAfterConfirmEmail(string userId, string userMail);
        ShopUserVm GetShopUserByIdentityUserId(string identityUserId);
        ShopUserWithAddressVm GetShopUserWithAddressByIdentityUserId(string identityUserId);
    }
}
