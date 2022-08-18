using BoardGamesShopMVC.Application.Interfaces;
using BoardGamesShopMVC.Application.ViewModels.Publisher;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace BoardGamesShopMVC.Web.Controllers
{
    public class PublisherController : Controller
    {
        private readonly IPublisherService _publisherService;
        private readonly IValidator<NewPublisherVm> _validator;
        public PublisherController(IPublisherService publisherService, IValidator<NewPublisherVm> validator)
        {
            _validator = validator;
            _publisherService = publisherService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var model = _publisherService.GetAllPublishers();
            return View(model);
        }
        [HttpGet]
        public IActionResult ViewBoardGamesByPublisher(int id)
        {
            var model = _publisherService.GetBoardGamesByPublisherId(id);
            return View(model);
        }
        [HttpGet]
        public IActionResult AddPublisher()
        {
            return View(new NewPublisherVm());
        }
        [HttpPost]
        public IActionResult AddPublisher(NewPublisherVm model)
        {
            ValidationResult result = _validator.Validate(model);
            if (!result.IsValid)
            {
                result.AddToModelState(this.ModelState);
                return View(new NewPublisherVm());
            }
            var id = _publisherService.AddPublisher(model);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            _publisherService.DeletePublisher(id);
            return RedirectToAction("Index");
        }
    }
}
