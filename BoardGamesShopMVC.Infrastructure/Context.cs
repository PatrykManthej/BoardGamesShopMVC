using BoardGamesShopMVC.Domain.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BoardGamesShopMVC.Infrastructure
{
    public class Context : IdentityDbContext
    {
        public Context(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<ContactDetail> ContactDetails { get; set; }
        public DbSet<ContactDetailType> ContactDetailTypes { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<BoardGame> BoardGames { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Stock> Stocks { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<BoardGame>().HasOne(b => b.LanguageVersion).WithMany(l => l.BoardGames).HasForeignKey(b => b.LanguageId);
            builder.Entity<BoardGame>().HasOne(b => b.Publisher).WithMany(p => p.BoardGames).HasForeignKey(b => b.PublisherId);
            builder.Entity<BoardGame>().HasOne(b => b.Stock).WithOne(s => s.BoardGame).HasForeignKey<BoardGame>(s => s.StockId);
            builder.Entity<BoardGame>().HasOne(b => b.CartItem).WithOne(c => c.BoardGame).HasForeignKey<CartItem>(c => c.BoardGameId);
            builder.Entity<BoardGame>().HasOne(b => b.OrderItem).WithOne(o => o.BoardGame).HasForeignKey<OrderItem>(o => o.BoardGameId);
            builder.Entity<BoardGame>().HasMany(b => b.Categories)
                .WithMany(c => c.BoardGames)
                .UsingEntity<BoardGameCategory>(bgcBuilder =>
                {
                    bgcBuilder.HasOne(bgc => bgc.BoardGame)
                    .WithMany()
                    .HasForeignKey(bgc => bgc.BoardGamesId);

                    bgcBuilder.HasOne(bgc => bgc.Category)
                    .WithMany()
                    .HasForeignKey(bgc => bgc.CategoriesId);

                    bgcBuilder.HasKey(bgc => new { bgc.BoardGamesId, bgc.CategoriesId });
                });

            builder.Entity<Cart>().HasOne(ca => ca.Customer).WithOne(cu => cu.Cart).HasForeignKey<Cart>(ca => ca.CustomerId);
            builder.Entity<Cart>().HasMany(ca => ca.CartItems).WithOne(ci => ci.Cart).HasForeignKey(ci => ci.CartId);

            builder.Entity<Order>().HasOne(o => o.Customer).WithMany(c => c.Orders).HasForeignKey(o => o.CustomerId);
            builder.Entity<Order>().HasMany(o => o.Items).WithOne(i => i.Order).HasForeignKey(i => i.OrderId);

            builder.Entity<Publisher>().Property(p => p.Name).HasMaxLength(50).IsRequired();

            builder.Entity<Publisher>().HasData
                (
                    new Publisher() { Id = 1, Name = "Bard" },
                    new Publisher() { Id = 2, Name = "Rebel" },
                    new Publisher() { Id = 3, Name = "Albi" }
                );
            builder.Entity<Language>().HasData
                (
                    new Language() { Id = 1, Name = "Polski" },
                    new Language() { Id = 2, Name = "Angielski" }
                );
            builder.Entity<BoardGame>().HasData
                (
                    new BoardGame() { Id = 1, Name = "Carcassonne", Description = "Usiądź z przyjaciółmi przy stole i wspólnie zacznijcie budować z niewielkich żetonów łąki, twierdze, całe miasta i drogi, rywalizując między sobą o przejęcie kontroli nad co bardziej atrakcyjnymi lokacjami.", AverageTimeOfPlay = "30 - 45 min", RecommendedMinimumAge = 7, MinNumberOfPlayers = 2, MaxNumberOfPlayers = 5, PublishedYear = 2000, Price = 120, LanguageId = 1, PublisherId = 1, ImageUrl= @"\images\boardgames\24cf50d0-b7ed-44f5-8269-20889c9ca1ba_Carcassonne.png", StockId = 1 },

                    new BoardGame() { Id = 2, Name = "Splendor", Description = "Splendor jest dynamiczną i niemal uzależniającą grą w zbieranie żetonów i kart, które tworzą zasoby gracza, umożliwiające mu dalszy rozwój. ", AverageTimeOfPlay = "30 min", RecommendedMinimumAge = 10, MinNumberOfPlayers = 2, MaxNumberOfPlayers = 4, PublishedYear = 2014, Price = 130, LanguageId = 1, PublisherId = 2, @ImageUrl = @"\images\boardgames\73c2c91e-e0ba-4405-98f2-4dc99f90229b_Splendor.jpg", StockId = 2 },

                    new BoardGame() { Id = 3, Name = "Nemesis", Description = "Nagle wybudzasz się z hibernacji. Gdy powoli odzyskujesz świadomość i kontrolę nad własnym ciałem, przypominasz sobie, że jesteś na statku kosmicznym \"Nemesis\".", AverageTimeOfPlay = "90 - 180 min", RecommendedMinimumAge = 12, MinNumberOfPlayers = 1, MaxNumberOfPlayers = 5, PublishedYear = 2018, Price = 500, LanguageId = 1, PublisherId = 2, ImageUrl = @"\images\boardgames\06718f78-7290-48fe-b889-34f48cd3cdfc_Nemesis.png", StockId = 3 },

                    new BoardGame() { Id = 4, Name = "Terraformacja Marsa", Description = "Zwiększenie odsetka imigracji z Ziemi wymaga terraformacji Marsa, czyli dostosowania jego środowiska, aby ludzie mogli w nim przeżyć bez sprzętu ochronnego i aby zminimalizować śmiertelność w wyniku drobnych wypadków. W związku z tym Rząd Ziemi zdecydował się wesprzeć każdą organizację, która przyczyni się do tego wiekopomnego dzieła.", AverageTimeOfPlay = "120 min", RecommendedMinimumAge = 12, MinNumberOfPlayers = 1, MaxNumberOfPlayers = 5, PublishedYear = 2016, Price = 130, LanguageId = 1, PublisherId = 2, ImageUrl = @"\images\boardgames\b4aca5a4-39f5-4557-9f22-d892ae5833ae_TerraformacjaMarsa.jpg", StockId = 4 },

                    new BoardGame() { Id = 5, Name = "Gloomhaven", Description = "Oto kooperacyjna gra taktyczna, stworzona przez miłośnika ekonomicznych gier Euro, w której wspólnymi siłami przedzieramy się przez nieustannie ewoluujący świat fantasy, rozgrywając kampanię fabularną na przestrzeni wielu sesji.Każdy gracz wciela się w postać twardego najemnika posiadającego unikalne zdolności i własną motywację. ", AverageTimeOfPlay = "60 - 120 min", RecommendedMinimumAge = 14, MinNumberOfPlayers = 1, MaxNumberOfPlayers = 4, PublishedYear = 2017, Price = 500, LanguageId = 1, PublisherId = 3, ImageUrl = @"\images\boardgames\3654de27-3880-416e-918d-669d34843189_Gloomhaven.jpg", StockId = 5 },

                    new BoardGame() { Id = 6, Name = "Everdell ", Description = "W uroczej dolinie Everdell, pod gałęziami wysokich drzew, wśród omszałych głazów, rozwija się cywilizacja leśnych zwierząt. Wiele lat minęło od jej początków i wreszcie nadszedł czas, by odkryć nowe tereny i zakładać zupełnie nowe miasta. ", AverageTimeOfPlay = "40 - 80 min", RecommendedMinimumAge = 13, MinNumberOfPlayers = 1, MaxNumberOfPlayers = 4, PublishedYear = 2018, Price = 200, LanguageId = 1, PublisherId = 2, ImageUrl = @"\images\boardgames\a51727e6-52ff-4aaa-ae76-3655d0deed84_Everdell.png", StockId = 6 },

                    new BoardGame() { Id = 7, Name = "7 Cudów Świata: Pojedynek", Description = "7 Cudów Świata: Pojedynek to gra dla 2 graczy, która wykorzystuje niektóre z głównych założeń bestselleru 7 Cudów Świata, ale oferuje również nowe wyzwania, specjalnie dopasowane do gry dwuosobowej.", AverageTimeOfPlay = "30 min", RecommendedMinimumAge = 10, MinNumberOfPlayers = 2, MaxNumberOfPlayers = 2, PublishedYear = 2015, Price = 120, LanguageId = 1, PublisherId = 2, ImageUrl = @"\images\boardgames\62a196ba-cb1e-46dd-953a-ecadd3fd7f48_7CudowPojedynek.jpg", StockId = 7}
                );

            builder.Entity<Category>().HasData
                (
                    new Category() { Id = 1, Name = "Strategiczne" },
                    new Category() { Id = 2, Name = "Przygodowe" }
                );
            builder.Entity<BoardGameCategory>().HasData
                (
                    new BoardGameCategory() { BoardGamesId = 1, CategoriesId = 1 },
                    new BoardGameCategory() { BoardGamesId = 2, CategoriesId = 1 },
                    new BoardGameCategory() { BoardGamesId = 3, CategoriesId = 2 }
                );
            builder.Entity<Cart>().HasData
                (
                    new Cart() { Id = 1, CustomerId = 1 }
                );
            builder.Entity<Customer>().HasData
               (
                   new Customer() { Id = 1, FirstName = "Test", LastName = "Test" }
               );
            builder.Entity<Stock>().HasData
                (
                   new Stock() { Id = 1, Quantity = 5},
                   new Stock() { Id = 2, Quantity = 7},
                   new Stock() { Id = 3, Quantity = 2},
                   new Stock() { Id = 4, Quantity = 4},
                   new Stock() { Id = 5, Quantity = 3},
                   new Stock() { Id = 6, Quantity = 6},
                   new Stock() { Id = 7, Quantity = 2}
                );

            base.OnModelCreating(builder);
        }
    }
}
