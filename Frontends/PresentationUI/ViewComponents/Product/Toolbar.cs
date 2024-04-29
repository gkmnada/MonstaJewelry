using Microsoft.AspNetCore.Mvc;

namespace PresentationUI.ViewComponents.Product
{
    public class Toolbar : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
