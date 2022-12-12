using System.Security.Principal;
using AutoMapper;
using BoardGamesShopMVC.Application.Interfaces;
using BoardGamesShopMVC.Application.ViewModels.ApplicationUser;
using BoardGamesShopMVC.Application.ViewModels.Cart;
using BoardGamesShopMVC.Domain.Interfaces;
using BoardGamesShopMVC.Domain.Model;

namespace BoardGamesShopMVC.Application.Services
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;
        private readonly IStockRepository _stockRepository;
        private readonly IMapper _mapper;
        public CartService(ICartRepository cartRepository, IStockRepository stockRepository, IMapper mapper)
        {
            _cartRepository = cartRepository;
            _stockRepository = stockRepository;
            _mapper = mapper;
        }

        public CartDetailsVm GetCart(string applicationUserId) 
        {
            var cart = _cartRepository.GetCartByUserId(applicationUserId);

            decimal total = 0;
            foreach (var item in cart.CartItems)
            {
                total += item.BoardGame.Price * item.Quantity;
            }
            cart.TotalAmount = total;
            _cartRepository.UpdateCart(cart);

            var cartVm = _mapper.Map<CartDetailsVm>(cart);
            foreach (var item in cartVm.CartItems)
            {
                item.Total = item.Price * item.Quantity;
            }
            return cartVm;
        }

        public int CreateCart(string applicationUserId)
        {
            var newCart = new Cart
            {
                ApplicationUserId = applicationUserId
            };

            var newCartId = _cartRepository.AddCart(newCart);
            return newCartId;
        }

        public void AddItemToCart(int boardGameId, int cartId)
        {
            var cart = _cartRepository.GetCartById(cartId);
            if(cart != null)
            {
                if (cart.CartItems == null)
                {
                    cart.CartItems = new List<CartItem>();
                }
                var cartItem = cart.CartItems.FirstOrDefault(c => c.BoardGameId == boardGameId);

                if(cartItem == null)
                {
                    var newCartItem = new CartItem()
                    {
                        Quantity = 1,
                        BoardGameId = boardGameId,
                        CartId = cartId
                    };
                    _cartRepository.AddCartItem(newCartItem);
                }
                else
                {
                    var boardGameStock = _stockRepository.GetStockByBoardGameId(boardGameId);
                    var boardGameStockQuantity = boardGameStock.Quantity;
                    var cartitemQuantity = cartItem.Quantity;
                    if (++cartitemQuantity <= boardGameStockQuantity)
                    {
                        cartItem.Quantity++;
                        _cartRepository.UpdateCartItem(cartItem);
                    }
                }
            }
        }

        public void DeleteCartItemFromCart(int cartItemId)
        {
            _cartRepository.DeleteCartItem(cartItemId);
        }

        public void IncrementCartItemQuantity(int cartId, int cartItemId)
        {
            var cart = _cartRepository.GetCartById(cartId);
            var cartItem = cart.CartItems.FirstOrDefault(i => i.Id == cartItemId);
            if(cartItem != null)
            {
                var boardGameId = cartItem.BoardGameId;
                var boardGameStock = _stockRepository.GetStockByBoardGameId(boardGameId);
                var boardGameStockQuantity = boardGameStock.Quantity;
                var cartitemQuantity = cartItem.Quantity;
                if (++cartitemQuantity <= boardGameStockQuantity)
                {
                    cartItem.Quantity++;
                    _cartRepository.UpdateCartItem(cartItem);
                }
            }
        }

        public void DecrementCartItemQuantity(int cartId, int cartItemId)
        {
            var cart = _cartRepository.GetCartById(cartId);
            var cartItem = cart.CartItems.FirstOrDefault(i => i.Id == cartItemId);
            if (cartItem != null)
            {
                cartItem.Quantity--;
                if(cartItem.Quantity <= 0)
                {
                    _cartRepository.DeleteCartItem(cartItemId);
                }
                else
                {
                _cartRepository.UpdateCartItem(cartItem);
                }
            }
        }

        public CartSummaryVm GetCartSummary(ApplicationUser user)
        {
            var cart = _cartRepository.GetCartByUserId(user.Id);
            var cartSummaryVm = _mapper.Map<CartSummaryVm>(cart);
            var applicationUserVm = _mapper.Map<ApplicationUserVm>(user);
            cartSummaryVm.ApplicationUserVm = applicationUserVm;

            foreach (var item in cartSummaryVm.CartItems)
            {
                item.Total = item.Price * item.Quantity;
            }
            return cartSummaryVm;
        }

        public void ClearCart(int cartId)
        {
            _cartRepository.DeleteCartItems(cartId);
        }
    }
}
