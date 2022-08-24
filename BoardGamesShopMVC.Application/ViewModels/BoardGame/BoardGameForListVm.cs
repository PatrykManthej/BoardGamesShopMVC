using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGamesShopMVC.Application.ViewModels.BoardGame
{
    public class BoardGameForListVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string? ImageSrc { get; set; }
    }
}
