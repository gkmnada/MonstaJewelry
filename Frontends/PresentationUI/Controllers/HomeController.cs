using Microsoft.AspNetCore.Mvc;

namespace PresentationUI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
