using BoardGamesShopMVC.Application.Interfaces;
using BoardGamesShopMVC.Application.ViewModels.Cart;
using BoardGamesShopMVC.Domain.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BoardGamesShopMVC.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly ICartService _cartService;
        private readonly IBoardGameService _boardGameService;
        private readonly IPaymentService _paymentService;
        private readonly UserManager<ApplicationUser> _userManager;

        public OrderController(IOrderService orderService, ICartService cartService, IBoardGameService boardGameService, IPaymentService paymentService, UserManager<ApplicationUser> userManager)
        {
            _orderService = orderService;
            _cartService = cartService;
            _boardGameService = boardGameService;
            _paymentService = paymentService;
            _userManager = userManager;
        }

        public IActionResult CreateOrder(CartSummaryVm cartVm)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var orderId = _orderService.CreateOrder(cartVm, userId);

            if (orderId == 0)
            {
                
            }

            var session = _paymentService.CreateStripeSession(cartVm, orderId);
            _orderService.UpdateOrderStripePaymentSessionId(orderId, session.Id, session.PaymentIntentId);

            Response.Headers.Add("Location", session.Url);
      
            return new StatusCodeResult(303);

        }

        public async Task<IActionResult> OrderConfirmation(int id)
        {
            var user = await _userManager.GetUserAsync(User);
            var cartVm = _cartService.GetCartSummary(user);

            _orderService.ConfirmOrder(id);

            _cartService.ClearCart(cartVm.Id);
            _boardGameService.RemoveBoardGamesFromStock(cartVm);

            return View(id);
        }
    }
}