using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGamesShopMVC.Application.ViewModels.BoardGame
{
    public class BoardGameDetailsVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string AverageTimeOfPlay { get; set; }
        public int RecommendedMinimumAge { get; set; }
        public int MinNumberOfPlayers { get; set; }
        public int MaxNumberOfPlayers { get; set; }
        public int PublishedYear { get; set; }
        public decimal Price { get; set; }
        public string? ImageSrc { get; set; }

        public string LanguageVersion { get; set; }
        public string Publisher { get; set; }
    }
}
