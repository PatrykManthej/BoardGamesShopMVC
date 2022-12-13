using BoardGamesShopMVC.Application.Interfaces;
using BoardGamesShopMVC.Application.ViewModels.Cart;
using Stripe.Checkout;

namespace BoardGamesShopMVC.Application.Services
{
    public class PaymentService : IPaymentService
    {
        public Session CreateStripeSession(CartSummaryVm cartVm, int orderId)
        {
            var domain = "https://localhost:7113/";

            var options = new SessionCreateOptions
            {
                LineItems = new List<SessionLineItemOptions>(),
                Mode = "payment",
                SuccessUrl = domain + $"Order/OrderConfirmation?id={orderId}",
                CancelUrl = domain + $"Cart/ViewCart",
            };

            foreach (var cartItem in cartVm.CartItems)
            {
                var sessionLineItem = new SessionLineItemOptions
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        UnitAmount = (long)(cartItem.Price * 100),
                        Currency = "pln",
                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = cartItem.Name,
                        },
                    },
                    Quantity = cartItem.Quantity,
                };
                options.LineItems.Add(sessionLineItem);
            }

            var service = new SessionService();
            Session session = service.Create(options);
            return session;
        }
    }
}
