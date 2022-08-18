using BoardGamesShopMVC.Application.Interfaces;
using BoardGamesShopMVC.Application.ViewModels.Publisher;
using Microsoft.AspNetCore.Mvc;

namespace BoardGamesShopMVC.Web.Controllers
{
    public class PublisherController : Controller
    {
        private readonly IPublisherService _publisherService;
        public PublisherController(IPublisherService publisherService)
        {
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
            var id = _publisherService.AddPublisher(model);
            return RedirectToAction("Index");
        }
    }
}
