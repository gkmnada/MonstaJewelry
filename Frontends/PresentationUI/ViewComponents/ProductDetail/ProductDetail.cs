using Microsoft.AspNetCore.Mvc;

namespace PresentationUI.ViewComponents.ProductDetail
{
    public class ProductDetail : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
