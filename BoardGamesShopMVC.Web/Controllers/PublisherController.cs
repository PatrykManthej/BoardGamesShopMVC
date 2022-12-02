using BoardGamesShopMVC.Application.Interfaces;
using BoardGamesShopMVC.Application.ViewModels.Publisher;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BoardGamesShopMVC.Web.Controllers
{
    [Authorize(Roles = "Admin, Employee")]
    public class PublisherController : Controller
    {
        private readonly IPublisherService _publisherService;
        private readonly IValidator<NewPublisherVm> _validator;
        public PublisherController(IPublisherService publisherService, IValidator<NewPublisherVm> validator)
        {
            _validator = validator;
            _publisherService = publisherService;
        }

        public IActionResult Index(string? searchString, int pageSize = 10, int pageNo = 1)
        {
            searchString ??= string.Empty;
            var model = _publisherService.GetAllPublishers(pageSize, pageNo, searchString);
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