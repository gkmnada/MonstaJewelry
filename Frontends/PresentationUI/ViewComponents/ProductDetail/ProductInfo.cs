using Microsoft.AspNetCore.Mvc;

namespace PresentationUI.ViewComponents.ProductDetail
{
    public class ProductInfo : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
