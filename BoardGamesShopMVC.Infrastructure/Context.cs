using BoardGamesShopMVC.Domain.Model.Customer;
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

        public DbSet<Address> Addresses  { get; set; }
        public DbSet<ContactDetail> ContactDetails  { get; set; }
        public DbSet<ContactDetailType> ContactDetailTypes  { get; set; }
        public DbSet<Customer> Customers  { get; set; }
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
            builder.Entity<BoardGame>().HasOne(b => b.LanguageVersion).WithMany(l => l.BoardGames).HasForeignKey(b => b.LanguageId);
            builder.Entity<BoardGame>().HasOne(b => b.Publisher).WithMany(p => p.BoardGames).HasForeignKey(b => b.PublisherId);
            builder.Entity<BoardGame>().HasOne(b => b.Stock).WithOne(s => s.BoardGame).HasForeignKey<Stock>(s => s.BoardGameId);
            builder.Entity<BoardGame>().HasOne(b => b.CartItem).WithOne(c => c.BoardGame).HasForeignKey<CartItem>(c => c.BoardGameId);
            builder.Entity<BoardGame>().HasOne(b => b.OrderItem).WithOne(o => o.BoardGame).HasForeignKey<OrderItem>(o => o.BoardGameId);
            builder.Entity<BoardGame>().HasMany(b => b.Categories).WithMany(c => c.BoardGames);
            builder.Entity<BoardGame>().HasMany(b => b.Tags).WithMany(t => t.BoardGames);

            builder.Entity<Cart>().HasOne(ca => ca.Customer).WithOne(cu => cu.Cart).HasForeignKey<Cart>(ca => ca.CustomerId);
            builder.Entity<Cart>().HasMany(ca => ca.CartItems).WithOne(ci => ci.Cart).HasForeignKey(ci => ci.CartId);

            builder.Entity<Order>().HasOne(o => o.Customer).WithMany(c => c.Orders).HasForeignKey(o => o.CustomerId);
            builder.Entity<Order>().HasMany(o => o.Items).WithOne(i => i.Order).HasForeignKey(i => i.OrderId);

            builder.Entity<CartItem>().Property(p => p.TotalPrice).HasComputedColumnSql("[Quantity]*[UnitPrice]");


            base.OnModelCreating(builder);
        }
    }
}
