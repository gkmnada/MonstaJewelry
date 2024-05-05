using Microsoft.AspNetCore.Mvc;

namespace PresentationUI.ViewComponents.ProductDetail
{
    public class RelatedProducts : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
