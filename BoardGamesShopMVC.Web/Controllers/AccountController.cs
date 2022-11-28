using BoardGamesShopMVC.Application.Interfaces;
using BoardGamesShopMVC.Application.ViewModels.ShopUser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BoardGamesShopMVC.Web.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IShopUserService _shopUserService;

        public AccountController(UserManager<IdentityUser> userManager, IShopUserService shopUserService)
        {
            _userManager = userManager;
            _shopUserService = shopUserService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var userId = _userManager.GetUserId(User);
            if (userId == null)
            {
                return NotFound("Unable to load user ID.");
            }

            var shopUser = _shopUserService.GetShopUserWithAddressByIdentityUserId(userId);
            return View(shopUser);
        }
        [HttpPost]
        public IActionResult Index(ShopUserWithAddressVm model)
        {
            var userId = _userManager.GetUserId(User);
            if (userId == null)
            {
                return NotFound("Unable to load user ID.");
            }
            _shopUserService.UpdateShopUser(model);
            return View();
        }
    }
}
