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
        public CartController(ICartService cartService, UserManager<ApplicationUser> userManager)
        {
            _cartService = cartService;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ViewCart()
        {
            var currentApplicationUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var model = _cartService.GetCart(currentApplicationUserId);
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

        public IActionResult Delete(int cartItemId)
        {
            _cartService.DeleteCartItemFromCart(cartItemId);
            return RedirectToAction("ViewCart");
        }

        public IActionResult Plus(int cartItemId)
        {
            _cartService.IncrementCartItemQuantity(cartItemId);
            return RedirectToAction("ViewCart");
        }

        public IActionResult Minus(int cartItemId)
        {
            _cartService.DecrementCartItemQuantity(cartItemId);
            return RedirectToAction("ViewCart");
        }

        [HttpGet]
        public async Task<IActionResult> CartSummary()
        {
            var user = await _userManager.GetUserAsync(User);
            var model = _cartService.GetCartSummary(user);
            return View(model);
        }
    }
}
