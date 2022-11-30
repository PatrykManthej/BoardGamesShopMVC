using AutoMapper;
using BoardGamesShopMVC.Application.Interfaces;
using BoardGamesShopMVC.Application.ViewModels.ApplicationUser;
using BoardGamesShopMVC.Domain.Interfaces;
using BoardGamesShopMVC.Domain.Model;

namespace BoardGamesShopMVC.Application.Services
{
    public class ApplicationUserService : IApplicationUserService
    {
        private readonly IApplicationUserRepository _applicationUserRepository;
        private readonly IMapper _mapper;

        public ApplicationUserService(IApplicationUserRepository applicationUserRepository, IMapper mapper)
        {
            _applicationUserRepository = applicationUserRepository;
            _mapper = mapper;
        }

        public string AddApplicationUserAfterConfirmEmail(string userId, string userMail)
        {
            var newApplicationUserVm = new NewApplicationUserVm
            {
                ApplicationUserId = userId,
                Email = userMail
            };

            var newApplicationUser = _mapper.Map<ApplicationUser>(newApplicationUserVm);

            var createdApplicationUserId = _applicationUserRepository.AddApplicationUser(newApplicationUser);
            return createdApplicationUserId;
        }

        public ApplicationUserVm GetApplicationUserById(string userId)
        {
            var ApplicationUser = _applicationUserRepository.GetApplicationUserById(userId);
            var ApplicationUserVm = _mapper.Map<ApplicationUserVm>(ApplicationUser);
            return ApplicationUserVm;
        }
    }
}
