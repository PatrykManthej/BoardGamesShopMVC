using BoardGamesShopMVC.Domain.Model;
using BoardGamesShopMVC.Domain.Model.Customer;
using BoardGamesShopMVC.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

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
            builder.Entity<BoardGame>().HasMany(b => b.Categories)
                .WithMany(c => c.BoardGames)
                .UsingEntity<BoardGameCategory>(bgcBuilder =>
                {
                    bgcBuilder.HasOne(bgc => bgc.BoardGame)
                    .WithMany()
                    .HasForeignKey(bgc => bgc.BoardGameId);

                    bgcBuilder.HasOne(bgc => bgc.Category)
                    .WithMany()
                    .HasForeignKey(bgc => bgc.CategoryId);
                });

            builder.Entity<BoardGame>().HasMany(b => b.Tags).WithMany(t => t.BoardGames);

            builder.Entity<Cart>().HasOne(ca => ca.Customer).WithOne(cu => cu.Cart).HasForeignKey<Cart>(ca => ca.CustomerId);
            builder.Entity<Cart>().HasMany(ca => ca.CartItems).WithOne(ci => ci.Cart).HasForeignKey(ci => ci.CartId);

            builder.Entity<Order>().HasOne(o => o.Customer).WithMany(c => c.Orders).HasForeignKey(o => o.CustomerId);
            builder.Entity<Order>().HasMany(o => o.Items).WithOne(i => i.Order).HasForeignKey(i => i.OrderId);

            builder.Entity<Publisher>().Property(p=>p.Name).HasMaxLength(50).IsRequired();


            builder.Entity<Publisher>().HasData
                (
                new Publisher() {Id=1, Name = "Bard" },
                new Publisher() { Id = 2, Name = "Rebel" }
                );
            builder.Entity<Language>().HasData
                (
                new Language() { Id = 1, Name = "Polski"},
                new Language() { Id = 2, Name = "Angielski"}
                );
            builder.Entity<BoardGame>().HasData
                (
                    new BoardGame() { Id = 1, Name = "Carcassonne", Description= "Usiądź z przyjaciółmi przy stole i wspólnie zacznijcie budować z niewielkich żetonów łąki, twierdze, całe miasta i drogi, rywalizując między sobą o przejęcie kontroli nad co bardziej atrakcyjnymi lokacjami.", AverageTimeOfPlay = "30 - 45 min", RecommendedMinimumAge = 7, MinNumberOfPlayers = 2, MaxNumberOfPlayers = 5, PublishedYear = 2000, Price = 120, LanguageId = 1, PublisherId = 1 },

                    new BoardGame() { Id = 2, Name = "Splendor", Description = "Splendor jest dynamiczną i niemal uzależniającą grą w zbieranie żetonów i kart, które tworzą zasoby gracza, umożliwiające mu dalszy rozwój. ", AverageTimeOfPlay = "30 min", RecommendedMinimumAge = 10, MinNumberOfPlayers = 2, MaxNumberOfPlayers = 4, PublishedYear = 2014, Price = 130, LanguageId = 1, PublisherId = 2},

                    new BoardGame() { Id = 3, Name = "Nemesis", Description = "Nagle wybudzasz się z hibernacji. Gdy powoli odzyskujesz świadomość i kontrolę nad własnym ciałem, przypominasz sobie, że jesteś na statku kosmicznym \"Nemesis\".", AverageTimeOfPlay = "90 - 180 min", RecommendedMinimumAge = 12, MinNumberOfPlayers = 1, MaxNumberOfPlayers = 5, PublishedYear = 2018, Price = 500, LanguageId = 1, PublisherId = 2}
                );

            builder.Entity<Category>().HasData
                (
                new Category() { Id = 1, Name = "Strategiczne" },
                new Category() { Id = 2, Name = "Przygodowe"}
                );
            builder.Entity<BoardGameCategory>().HasData
                (
                new BoardGameCategory() { BoardGameId = 1, CategoryId = 1 },
                new BoardGameCategory() { BoardGameId = 2, CategoryId = 1 },
                new BoardGameCategory() { BoardGameId = 3, CategoryId = 2 }
                );

            base.OnModelCreating(builder);
        }
    }
}
