using BoardGamesShopMVC.Application.ViewModels.Category;
using BoardGamesShopMVC.Application.ViewModels.Language;
using BoardGamesShopMVC.Application.ViewModels.Publisher;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace BoardGamesShopMVC.Application.ViewModels.BoardGame
{
    public class NewBoardGameVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string AverageTimeOfPlay { get; set; }
        public int RecommendedMinimumAge { get; set; }
        public int MinNumberOfPlayers { get; set; }
        public int MaxNumberOfPlayers { get; set; }
        public int PublishedYear { get; set; }
        public decimal Price { get; set; }
        public IFormFile? ImageFile{ get; set; }
        public string ImageUrl { get; set; }
        public int LanguageId { get; set; }
        public int PublisherId { get; set; }
        public List<PublisherForListVm> Publishers { get; set; }
        public List<CategoryForListVm> Categories { get; set; }
        public List<int> CategoriesId { get; set; }
        public List<LanguageForListVm> Languages { get; set; }
        public int StockQuantity { get; set; }
    }
    public class NewBoardGameValidation : AbstractValidator<NewBoardGameVm>
    {
        public NewBoardGameValidation()
        {
            RuleFor(b => b.Id).NotNull();
            RuleFor(b => b.Name).MinimumLength(1).MaximumLength(100);
            RuleFor(b => b.Description).MaximumLength(5000);
            RuleFor(b => b.AverageTimeOfPlay).MaximumLength(10);
            RuleFor(b => b.RecommendedMinimumAge).InclusiveBetween(0, 125);
            RuleFor(b => b.MinNumberOfPlayers).InclusiveBetween(1, 100);
            RuleFor(b => b.MaxNumberOfPlayers).GreaterThanOrEqualTo(1);
            RuleFor(b => b.PublishedYear).GreaterThanOrEqualTo(0);
            RuleFor(b => b.Price).InclusiveBetween(0, 100000000);
        }
    }
}
