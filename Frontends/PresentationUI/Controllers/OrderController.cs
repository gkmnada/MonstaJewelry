using Microsoft.AspNetCore.Mvc;

namespace PresentationUI.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
