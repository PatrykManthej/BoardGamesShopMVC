using AutoMapper;
using BoardGamesShopMVC.Application.ViewModels.BoardGame;
using BoardGamesShopMVC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGamesShopMVC.Application.Profiles.Resolvers
{
    public class AddBoardGameImageResolver : IValueResolver<NewBoardGameVm, BoardGame, byte[]?>
    {
        public byte[]? Resolve(NewBoardGameVm source, BoardGame destination, byte[]? destMember, ResolutionContext context)
        {
            byte[] bytes;
            using (var memoryStream = new MemoryStream())
            {
                source.ImageFile.CopyTo(memoryStream);
                bytes = memoryStream.ToArray();
            }
            return bytes;
        }
    }
}
