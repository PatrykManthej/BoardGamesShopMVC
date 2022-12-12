using System.Security.Claims;
using BoardGamesShopMVC.Application.Interfaces;
using BoardGamesShopMVC.Application.ViewModels.Cart;
using BoardGamesShopMVC.Domain.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BoardGamesShopMVC.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly ICartService _cartService;
        private readonly IBoardGameService _boardGameService;

        public OrderController(IOrderService orderService, ICartService cartService, IBoardGameService boardGameService)
        {
            _orderService = orderService;
            _cartService = cartService;
            _boardGameService = boardGameService;
        }

        public IActionResult CreateOrder(CartSummaryVm cartVm)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var orderId = _orderService.CreateOrder(cartVm, userId);
            if (orderId != 0)
            {
                _cartService.ClearCart(cartVm.Id);
                _boardGameService.RemoveBoardGamesFromStock(cartVm);
                
            }
            return RedirectToAction("Index", "BoardGame");
        }
    }
}
