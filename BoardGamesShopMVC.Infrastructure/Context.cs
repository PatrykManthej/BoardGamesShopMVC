using BoardGamesShopMVC.Domain.Model;
using BoardGamesShopMVC.Domain.Model.Common;
using Microsoft.AspNetCore.Identity;
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
                    new Publisher() { Id = 1, Name = "Bard", StatusId = 1 },
                    new Publisher() { Id = 2, Name = "Rebel", StatusId = 1 },
                    new Publisher() { Id = 3, Name = "Albi", StatusId = 1 },
                    new Publisher() { Id = 4, Name = "Lucky Duck Games", StatusId = 1 },
                    new Publisher() { Id = 5, Name = "Lacerta", StatusId = 1 }
                );
            builder.Entity<Language>().HasData
                (
                    new Language() { Id = 1, Name = "Polski", StatusId = 1 },
                    new Language() { Id = 2, Name = "Angielski", StatusId = 1 }
                );
            builder.Entity<BoardGame>().HasData
                (
                    new BoardGame() { Id = 1, Name = "Carcassonne", Description = "Usiądź z przyjaciółmi przy stole i wspólnie zacznijcie budować z niewielkich żetonów łąki, twierdze, całe miasta i drogi, rywalizując między sobą o przejęcie kontroli nad co bardziej atrakcyjnymi lokacjami.", AverageTimeOfPlay = "30 - 45 min", RecommendedMinimumAge = 7, MinNumberOfPlayers = 2, MaxNumberOfPlayers = 5, PublishedYear = 2000, Price = 120, LanguageId = 1, PublisherId = 1, ImageUrl= @"\images\boardgames\24cf50d0-b7ed-44f5-8269-20889c9ca1ba_Carcassonne.png", StockId = 1, StatusId = 1 },

                    new BoardGame() { Id = 2, Name = "Splendor", Description = "Splendor jest dynamiczną i niemal uzależniającą grą w zbieranie żetonów i kart, które tworzą zasoby gracza, umożliwiające mu dalszy rozwój. ", AverageTimeOfPlay = "30 min", RecommendedMinimumAge = 10, MinNumberOfPlayers = 2, MaxNumberOfPlayers = 4, PublishedYear = 2014, Price = 130, LanguageId = 1, PublisherId = 2, @ImageUrl = @"\images\boardgames\73c2c91e-e0ba-4405-98f2-4dc99f90229b_Splendor.jpg", StockId = 2, StatusId = 1 },

                    new BoardGame() { Id = 3, Name = "Nemesis", Description = "Nagle wybudzasz się z hibernacji. Gdy powoli odzyskujesz świadomość i kontrolę nad własnym ciałem, przypominasz sobie, że jesteś na statku kosmicznym \"Nemesis\".", AverageTimeOfPlay = "90 - 180 min", RecommendedMinimumAge = 12, MinNumberOfPlayers = 1, MaxNumberOfPlayers = 5, PublishedYear = 2018, Price = 500, LanguageId = 1, PublisherId = 2, ImageUrl = @"\images\boardgames\06718f78-7290-48fe-b889-34f48cd3cdfc_Nemesis.png", StockId = 3, StatusId = 1 },

                    new BoardGame() { Id = 4, Name = "Jaipur", Description = "W stolicy Radżastanu trwają poszukiwania nowego ministra handlu. Jako jeden z najlepszych w swoim fachu, postanawiasz podjąć wyzwanie i zgromadzić więcej bogactw od przeciwnika.", AverageTimeOfPlay = "30 min", RecommendedMinimumAge = 10, MinNumberOfPlayers = 2, MaxNumberOfPlayers = 2, PublishedYear = 2009, Price = 85, LanguageId = 1, PublisherId = 2, ImageUrl = @"\images\boardgames\28dcf532-2dd8-4337-b031-7f89f90a1533_Jaipur.png", StockId = 4, StatusId = 1 },

                    new BoardGame() { Id = 5, Name = "Gloomhaven", Description = "Oto kooperacyjna gra taktyczna, stworzona przez miłośnika ekonomicznych gier Euro, w której wspólnymi siłami przedzieramy się przez nieustannie ewoluujący świat fantasy, rozgrywając kampanię fabularną na przestrzeni wielu sesji.Każdy gracz wciela się w postać twardego najemnika posiadającego unikalne zdolności i własną motywację. ", AverageTimeOfPlay = "60 - 120 min", RecommendedMinimumAge = 14, MinNumberOfPlayers = 1, MaxNumberOfPlayers = 4, PublishedYear = 2017, Price = 500, LanguageId = 1, PublisherId = 3, ImageUrl = @"\images\boardgames\3654de27-3880-416e-918d-669d34843189_Gloomhaven.jpg", StockId = 5, StatusId = 1 },

                    new BoardGame() { Id = 6, Name = "Everdell ", Description = "W uroczej dolinie Everdell, pod gałęziami wysokich drzew, wśród omszałych głazów, rozwija się cywilizacja leśnych zwierząt. Wiele lat minęło od jej początków i wreszcie nadszedł czas, by odkryć nowe tereny i zakładać zupełnie nowe miasta. ", AverageTimeOfPlay = "40 - 80 min", RecommendedMinimumAge = 13, MinNumberOfPlayers = 1, MaxNumberOfPlayers = 4, PublishedYear = 2018, Price = 200, LanguageId = 1, PublisherId = 2, ImageUrl = @"\images\boardgames\a51727e6-52ff-4aaa-ae76-3655d0deed84_Everdell.png", StockId = 6, StatusId = 1 },

                    new BoardGame() { Id = 7, Name = "Kaskadia ", Description = "Przenieś się do malowniczej krainy w Północnej Ameryce i stwórz pełne życia środowisko Kaskadii. W swojej turze wybierz parę płytki oraz żetonu i dołóż je do swojego rozrastającego się ekosystemu. Ułóż jak największe obszary gór, rzek czy prerii oraz rozmieść zwierzęta w punktowanych układach.", AverageTimeOfPlay = "30 - 45 min", RecommendedMinimumAge = 10, MinNumberOfPlayers = 1, MaxNumberOfPlayers = 4, PublishedYear = 2021, Price = 150, LanguageId = 1, PublisherId = 4, ImageUrl = @"\images\boardgames\ebb22f92-1c40-4dd1-8266-7d3b55a588be_Kaskadia.png", StockId = 7, StatusId = 1 },

                    new BoardGame() { Id = 8, Name = "Patchwork", Description = "Patchwork to metoda szycia, w której łączy się małe kawałki materiału w większą całość, tworząc nowy wzór. W przeszłości wykorzystywano ją, żeby zagospodarować niechciane ścinki i skrawki.", AverageTimeOfPlay = "30 min", RecommendedMinimumAge = 8, MinNumberOfPlayers = 2, MaxNumberOfPlayers = 2, PublishedYear = 2014, Price = 90, LanguageId = 1, PublisherId = 5, ImageUrl = @"\images\boardgames\190d7868-947b-4256-9d51-e5f48dfde516_Patchwork.jpg", StockId = 8, StatusId = 1 },

                    new BoardGame() { Id = 9, Name = "Tajniacy", Description = "Dwie drużyny, którym przewodzi dwóch Szefów Wywiadu, próbują jak najszybciej nawiązać kontakt ze wszystkimi swoimi agentami.", AverageTimeOfPlay = "10 min", RecommendedMinimumAge = 14, MinNumberOfPlayers = 2, MaxNumberOfPlayers = 8, PublishedYear = 2015, Price = 60, LanguageId = 1, PublisherId = 2, ImageUrl = @"\images\boardgames\4aa3ec2a-03a3-41ff-b471-e0386f40a5e3_Tajniacy.jpg", StockId = 9, StatusId = 1 },

                    new BoardGame() { Id = 10, Name = "Azul", Description = "Azulejos - oryginalnie były to biało-niebieskie płytki ceramiczne, sprowadzone do Europy przez Maurów. Sławę i popularność w Portugalii zdobyły po wizycie króla Manuela I w południowej Hiszpanii.", AverageTimeOfPlay = "30 - 45 min", RecommendedMinimumAge = 8, MinNumberOfPlayers = 2, MaxNumberOfPlayers = 4, PublishedYear = 2017, Price = 230, LanguageId = 1, PublisherId = 5, ImageUrl = @"\images\boardgames\87c21d47-dc5a-41c8-aa5f-d0ff1a932691_Azul.jpg", StockId = 10, StatusId = 1 },

                    new BoardGame() { Id = 11, Name = "Agricola ", Description = "Przenieśmy się w czasie do roku 1670. Zaraza szalejąca w Europie Środkowej od 1348 roku w końcu została przezwyciężona. Na nowo odżywa cywilizacja. Ludzie coraz częściej odnawiają i rozbudowują swoje domostwa.", AverageTimeOfPlay = "90 min", RecommendedMinimumAge = 12, MinNumberOfPlayers = 1, MaxNumberOfPlayers = 4, PublishedYear = 2007, Price = 270, LanguageId = 1, PublisherId = 5, ImageUrl = @"\images\boardgames\a4bb9edb-b355-4b5b-ab51-3aaa4af38e82_Agricola.jpg", StockId = 11, StatusId = 1 },

                    new BoardGame() { Id = 12, Name = "Pandemic ", Description = "Cztery choroby wydostały się na świat i przed drużyną specjalistów z różnych dziedzin stanęło zadanie odnalezienia szczepionek na te epidemie, zanim ludzkość zostanie unicestwiona.", AverageTimeOfPlay = "60 min", RecommendedMinimumAge = 10, MinNumberOfPlayers = 2, MaxNumberOfPlayers = 4, PublishedYear = 2008, Price = 170, LanguageId = 1, PublisherId = 2, ImageUrl = @"\images\boardgames\7803a237-b779-4669-a386-94ef32e1ac7a_Pandemic.jpg", StockId = 12, StatusId = 1 }
                );

            builder.Entity<Category>().HasData
                (
                    new Category() { Id = 1, Name = "Strategiczne", StatusId = 1 },
                    new Category() { Id = 2, Name = "Przygodowe", StatusId = 1 },
                    new Category() { Id = 3, Name = "Rodzinne", StatusId = 1 },
                    new Category() { Id = 4, Name = "Imprezowe", StatusId = 1 }
                );
            builder.Entity<BoardGameCategory>().HasData
                (
                    new BoardGameCategory() { BoardGamesId = 1, CategoriesId = 1 },
                    new BoardGameCategory() { BoardGamesId = 2, CategoriesId = 1 },
                    new BoardGameCategory() { BoardGamesId = 3, CategoriesId = 2 },
                    new BoardGameCategory() { BoardGamesId = 4, CategoriesId = 3 },
                    new BoardGameCategory() { BoardGamesId = 5, CategoriesId = 2 },
                    new BoardGameCategory() { BoardGamesId = 6, CategoriesId = 1 },
                    new BoardGameCategory() { BoardGamesId = 7, CategoriesId = 3 },
                    new BoardGameCategory() { BoardGamesId = 8, CategoriesId = 3 },
                    new BoardGameCategory() { BoardGamesId = 9, CategoriesId = 4 },
                    new BoardGameCategory() { BoardGamesId = 10, CategoriesId = 3 },
                    new BoardGameCategory() { BoardGamesId = 11, CategoriesId = 1 },
                    new BoardGameCategory() { BoardGamesId = 12, CategoriesId = 1 }
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
                   new Stock() { Id = 1, Quantity = 5, StatusId = 1 },
                   new Stock() { Id = 2, Quantity = 7, StatusId = 1 },
                   new Stock() { Id = 3, Quantity = 2, StatusId = 1 },
                   new Stock() { Id = 4, Quantity = 4, StatusId = 1},
                   new Stock() { Id = 5, Quantity = 3, StatusId = 1},
                   new Stock() { Id = 6, Quantity = 6, StatusId = 1},
                   new Stock() { Id = 7, Quantity = 2, StatusId = 1},
                   new Stock() { Id = 8, Quantity = 3, StatusId = 1},
                   new Stock() { Id = 9, Quantity = 2, StatusId = 1 },
                   new Stock() { Id = 10, Quantity = 2, StatusId = 1},
                   new Stock() { Id = 11, Quantity = 5, StatusId = 1},
                   new Stock() { Id = 12, Quantity = 6, StatusId = 1 }
                );
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = "Admin", Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Id = "Employee", Name = "Employee", NormalizedName= "EMPLOYEE"},
                new IdentityRole { Id = "User", Name = "User", NormalizedName = "USER"}
                );

            base.OnModelCreating(builder);
        }
        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Created = DateTime.Now;
                        entry.Entity.StatusId = 1;
                        break;
                    case EntityState.Modified:
                        entry.Entity.Modified = DateTime.Now;
                        break;
                    case EntityState.Deleted:
                        entry.Entity.Modified = DateTime.Now;
                        entry.Entity.Inactivated = DateTime.Now;
                        entry.Entity.StatusId = 0;
                        entry.State = EntityState.Modified;
                        break;
                }
            }
            return base.SaveChanges();
        }
    }
}
