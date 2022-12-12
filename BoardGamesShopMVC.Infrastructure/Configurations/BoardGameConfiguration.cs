using BoardGamesShopMVC.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoardGamesShopMVC.Infrastructure.Configurations
{
    public class BoardGameConfiguration : IEntityTypeConfiguration<BoardGame>
    {
        public void Configure(EntityTypeBuilder<BoardGame> builder)
        {
            builder.HasOne(b => b.LanguageVersion).WithMany(l => l.BoardGames).HasForeignKey(b => b.LanguageId);

            builder.HasOne(b => b.Publisher).WithMany(p => p.BoardGames).HasForeignKey(b => b.PublisherId);

            builder.HasOne(b => b.Stock).WithOne(s => s.BoardGame).HasForeignKey<BoardGame>(s => s.StockId);

            builder.HasMany(b => b.CartItems).WithOne(c => c.BoardGame).HasForeignKey(x=>x.BoardGameId);

            builder.HasMany(b => b.OrderItems).WithOne(o => o.BoardGame).HasForeignKey(o => o.BoardGameId);

            builder.HasMany(b => b.Categories)
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

            #region DataSeed

            builder.HasData
                (
                    new BoardGame() { Id = 1, Name = "Carcassonne", Description = "Usiądź z przyjaciółmi przy stole i wspólnie zacznijcie budować z niewielkich żetonów łąki, twierdze, całe miasta i drogi, rywalizując między sobą o przejęcie kontroli nad co bardziej atrakcyjnymi lokacjami.", AverageTimeOfPlay = "30 - 45 min", RecommendedMinimumAge = 7, MinNumberOfPlayers = 2, MaxNumberOfPlayers = 5, PublishedYear = 2000, Price = 120, LanguageId = 1, PublisherId = 1, ImageUrl = @"\images\boardgames\24cf50d0-b7ed-44f5-8269-20889c9ca1ba_Carcassonne.png", StockId = 1, StatusId = 1 },

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

            #endregion

        }
    }
}
