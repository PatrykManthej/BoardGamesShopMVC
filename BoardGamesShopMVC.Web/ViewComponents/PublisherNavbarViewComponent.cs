using BoardGamesShopMVC.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BoardGamesShopMVC.Web.ViewComponents
{
    public class PublisherNavbarViewComponent : ViewComponent
    {
        private readonly IPublisherService _publisherService;
        public PublisherNavbarViewComponent(IPublisherService publisherService)
        {
            _publisherService = publisherService;
        }

        public IViewComponentResult Invoke()
        {
            var model = _publisherService.GetAllPublishers(20, 1, "");
            return View(model);
        }
    }
}
