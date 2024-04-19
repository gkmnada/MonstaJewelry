using Microsoft.AspNetCore.Mvc;

namespace PresentationUI.ViewComponents.Home
{
    public class BestSellers : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
