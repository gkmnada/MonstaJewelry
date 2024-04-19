using Microsoft.AspNetCore.Mvc;

namespace PresentationUI.ViewComponents.Home
{
    public class Newsletter : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
