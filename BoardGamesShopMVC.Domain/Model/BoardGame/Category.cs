﻿using BoardGamesShopMVC.Domain.Model.Common;

namespace BoardGamesShopMVC.Domain.Model
{
    public class Category : AuditableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<BoardGame> BoardGames { get; set; }
    }
}
