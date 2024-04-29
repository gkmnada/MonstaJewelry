using Microsoft.AspNetCore.Mvc;

namespace PresentationUI.ViewComponents.Product
{
    public class Products : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
