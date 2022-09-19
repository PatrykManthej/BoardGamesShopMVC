using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGamesShopMVC.Application.ViewModels.Category
{
    public class NewCategoryVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class NewCategoryValidation : AbstractValidator<NewCategoryVm>
    {
        public NewCategoryValidation()
        {
            RuleFor(p => p.Name).NotEmpty().NotNull().MaximumLength(50)
                .Matches(@"^[^\s]+(\s+[^\s]+)*$").WithMessage("Please ensure that you have not start or end with a whitespace");
        }
    }
}
