using AutoMapper;
using BoardGamesShopMVC.Application.Interfaces;
using BoardGamesShopMVC.Application.ViewModels.ShopUser;
using BoardGamesShopMVC.Domain.Interfaces;
using BoardGamesShopMVC.Domain.Model;

namespace BoardGamesShopMVC.Application.Services
{
    public class ShopUserService : IShopUserService
    {
        private readonly IShopUserRepository _shopUserRepository;
        private readonly IMapper _mapper;

        public ShopUserService(IShopUserRepository shopUserRepository, IMapper mapper)
        {
            _shopUserRepository = shopUserRepository;
            _mapper = mapper;
        }

        public int AddShopUserAfterConfirmEmail(string userId, string userMail)
        {
            var newShopUserVm = new NewShopUserVm
            {
                IdentityUserId = userId,
                Email = userMail
            };

            var newShopUser = _mapper.Map<ShopUser>(newShopUserVm);

            var createdShopUserId = _shopUserRepository.AddShopUser(newShopUser);
            return createdShopUserId;
        }

        public ShopUserVm GetShopUserByIdentityUserId(string identityUserId)
        {
            var shopUser = _shopUserRepository.GetShopUserByIdentityUserId(identityUserId);
            var shopUserVm = _mapper.Map<ShopUserVm>(shopUser);
            return shopUserVm;
        }

        public ShopUserWithAddressVm GetShopUserWithAddressByIdentityUserId(string identityUserId)
        {
            var shopUser = _shopUserRepository.GetShopUserWithAddressByIdentityUserId(identityUserId);
            var shopUserWithAddressVm = _mapper.Map<ShopUserWithAddressVm>(shopUser);
            return shopUserWithAddressVm;
        }
    }
}
