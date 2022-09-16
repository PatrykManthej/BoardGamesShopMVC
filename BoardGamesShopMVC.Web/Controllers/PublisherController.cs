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
            var model = _publisherService.GetAllPublishers(10, 1, "");
            return View(model);
        }
        [HttpPost]
        public IActionResult Index(int pageSize, int? pageNo, string searchString)
        {
            if (!pageNo.HasValue)
            {
                pageNo = 1;
            }
            if (searchString is null)
            {
                searchString = string.Empty;
            }
            if (pageSize == null || pageSize == 0)
            {
                pageSize = 10;
            }
            var model = _publisherService.GetAllPublishers(pageSize, pageNo.Value, searchString);
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
        [HttpGet]
        public IActionResult EditPublisher(int id)
        {
            var publisher = _publisherService.GetPublisherForEdit(id);
            return View(publisher);
        }
        [HttpPost]
        public IActionResult EditPublisher(NewPublisherVm model)
        {
            ValidationResult result = _validator.Validate(model);
            if (!result.IsValid)
            {
                result.AddToModelState(this.ModelState);
                return View(model);
            }
            _publisherService.UpdatePublisher(model);
            return RedirectToAction("Index");
        }
    }
}
