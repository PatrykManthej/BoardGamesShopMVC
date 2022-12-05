using AutoMapper;
using BoardGamesShopMVC.Application.ViewModels.ApplicationUser;
using BoardGamesShopMVC.Domain.Model;

namespace BoardGamesShopMVC.Application.Profiles
{
    public class ApplicationUserProfile : Profile
    {
        public ApplicationUserProfile()
        {
            CreateMap<ApplicationUser, ApplicationUserVm>();
        }
    }
}
