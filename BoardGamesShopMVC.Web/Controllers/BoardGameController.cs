using BoardGamesShopMVC.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace BoardGamesShopMVC.Web.Controllers
{
    public class BoardGameController : Controller
    {
        //Dodanie widoku dodawania gry planszowej do sklepu i obsługa
        //Dodanie widoku listy wszystkich gier i obsługa
        //Dodanie widoku detali gry i obsługa
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
