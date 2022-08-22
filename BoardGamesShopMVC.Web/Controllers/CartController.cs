using BoardGamesShopMVC.Application.Interfaces;
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
    }
}
