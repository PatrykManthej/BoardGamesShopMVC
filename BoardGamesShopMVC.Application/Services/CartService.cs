using AutoMapper;
using BoardGamesShopMVC.Application.Interfaces;
using BoardGamesShopMVC.Application.ViewModels.Cart;
using BoardGamesShopMVC.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGamesShopMVC.Application.Services
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;
        private readonly ICartItemRepository _cartItemRepository;
        private readonly IMapper _mapper;
        public CartService(ICartRepository cartRepository,ICartItemRepository cartItemRepository, IMapper mapper)
        {
            _cartRepository = cartRepository;
            _cartItemRepository = cartItemRepository;
            _mapper = mapper;
        }
        public CartDetailsVm ViewCart() 
        {
            var cart = _cartRepository.GetCartById(3);
            var cartVm = _mapper.Map<CartDetailsVm>(cart);
            foreach (var item in cartVm.CartItems)
            {
                item.Total = item.Price * item.Quantity;
            }
            
            return cartVm;
        }

        public void AddItemToCart(int boardGameId, int cartId)
        {
            _cartRepository.AddItemToCart(cartId, boardGameId);
        }

        public void DeleteCartItemFromCart(int cartItemId)
        {
            _cartRepository.DeleteItemFromCart(3,cartItemId);
        }
    }
}
