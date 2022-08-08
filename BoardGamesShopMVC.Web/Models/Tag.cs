﻿namespace BoardGamesShopMVC.Web.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<BoardGame> BoardGames { get; set; }
    }
}
