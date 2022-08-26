using AutoMapper;
using BoardGamesShopMVC.Application.ViewModels.Publisher;
using BoardGamesShopMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGamesShopMVC.Application.Profiles
{
    public class PublisherProfile : Profile
    {
        public PublisherProfile()
        {
            CreateMap<Publisher, PublisherForListVm>();
            CreateMap<NewPublisherVm, Publisher>().ReverseMap();
        }
    }
}
