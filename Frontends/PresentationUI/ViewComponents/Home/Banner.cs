using Microsoft.AspNetCore.Mvc;

namespace PresentationUI.ViewComponents.Home
{
    public class Banner : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
