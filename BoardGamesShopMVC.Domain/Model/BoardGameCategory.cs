﻿using BoardGamesShopMVC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGamesShopMVC.Domain.Model
{
    public class BoardGameCategory
    {
        public BoardGame BoardGame { get; set; }
        public int BoardGameId { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
    }
}
