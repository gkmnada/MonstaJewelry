using Microsoft.AspNetCore.Mvc;

namespace PresentationUI.ViewComponents.Home
{
    public class Slider : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
