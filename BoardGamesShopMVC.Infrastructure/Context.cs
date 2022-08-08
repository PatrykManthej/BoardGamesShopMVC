using BoardGamesShopMVC.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGamesShopMVC.Infrastructure
{
    public class Context : IdentityDbContext
    {
        public Context(DbContextOptions options) : base(options)
        {

        }

        public DbSet<BoardGame> BoardGames { get; set; }
        public DbSet<Cart> Carts{ get; set; }
        public DbSet<CartItem> CartItems{ get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<BoardGame>().HasOne(b => b.Stock)
                .WithOne(s => s.BoardGame).HasForeignKey<Stock>(s => s.BoardGameId);


            base.OnModelCreating(builder);
        }
    }
}
