﻿namespace BoardGamesShopMVC.Domain.Model
{
    public class Cart
    {
        public int Id { get; set; }
        public decimal TotalAmount { get; set; }

        public ShopUser ShopUser { get; set; }
        public int ShopUserId { get; set; }
        public ICollection<CartItem> CartItems { get; set; }
    }
}
