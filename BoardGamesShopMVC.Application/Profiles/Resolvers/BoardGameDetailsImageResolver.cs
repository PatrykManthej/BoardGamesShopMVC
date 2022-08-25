using AutoMapper;
using BoardGamesShopMVC.Application.ViewModels.BoardGame;
using BoardGamesShopMVC.Domain.Models;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGamesShopMVC.Application.Profiles.Resolvers
{
    public class BoardGameDetailsImageResolver : IValueResolver<BoardGame, BoardGameDetailsVm, string>
    {
        private readonly IWebHostEnvironment _hostEnvironment;
        public BoardGameDetailsImageResolver(IWebHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
        }
        public string Resolve(BoardGame source, BoardGameDetailsVm destination, string destMember, ResolutionContext context)
        {
            string wwwRootPath = _hostEnvironment.WebRootPath;
            var imageFilePath = Path.Combine(wwwRootPath, source.ImageUrl);
            return imageFilePath;
        }
    }
}
