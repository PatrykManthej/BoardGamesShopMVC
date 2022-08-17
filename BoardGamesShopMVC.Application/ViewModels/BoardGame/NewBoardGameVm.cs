﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGamesShopMVC.Application.ViewModels.BoardGame
{
    public class NewBoardGameVm
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
        public int LanguageId { get; set; }
        public int PublisherId { get; set; }
    }
}