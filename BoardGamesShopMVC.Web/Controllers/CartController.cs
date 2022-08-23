using BoardGamesShopMVC.Application.Interfaces;
using BoardGamesShopMVC.Application.ViewModels.Cart;
using Microsoft.AspNetCore.Mvc;

namespace BoardGamesShopMVC.Web.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult ViewCart()
        {
            var model = _cartService.ViewCart();
            return View(model);
        }
        [HttpPost]
        public IActionResult ViewCart(CartDetailsVm modelTo)
        {
            return View(modelTo);
        }
        public IActionResult AddToCart(int id)
        {
            _cartService.AddItemToCart(id, 3);
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
