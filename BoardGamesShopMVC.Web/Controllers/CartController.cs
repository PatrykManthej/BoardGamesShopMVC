using System.Security.Claims;
using BoardGamesShopMVC.Application.Interfaces;
using BoardGamesShopMVC.Application.ViewModels.Cart;
using BoardGamesShopMVC.Domain.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BoardGamesShopMVC.Web.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IApplicationUserService _applicationUserService;
        public CartController(ICartService cartService, UserManager<ApplicationUser> userManager, IApplicationUserService applicationUserService)
        {
            _cartService = cartService;
            _userManager = userManager;
            _applicationUserService = applicationUserService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ViewCart()
        {
            var currentApplicationUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var currentapplicationUser = _applicationUserService.GetApplicationUserById(currentApplicationUserId);
            var model = _cartService.ViewCart(currentapplicationUser.Id);
            return View(model);
        }

        [HttpPost]
        public IActionResult ViewCart(CartDetailsVm modelTo)
        {
            return View(modelTo);
        }

        public IActionResult AddToCart(int id)
        {
            _cartService.AddItemToCart(id, 1);
            return RedirectToAction("Index", "BoardGame");
        }

        public IActionResult Delete(int id)
        {
            _cartService.DeleteCartItemFromCart(id);
            return RedirectToAction("ViewCart");
        }

        public IActionResult Plus(int cartId, int cartItemId)
        {
            _cartService.IncrementCartItemQuantity(cartId, cartItemId);
            return RedirectToAction("ViewCart");
        }

        public IActionResult Minus(int cartId, int cartItemId)
        {
            _cartService.DecrementCartItemQuantity(cartId, cartItemId);
            return RedirectToAction("ViewCart");
        }
    }
}
