using Microsoft.AspNetCore.Mvc;

namespace PresentationUI.ViewComponents.Product
{
    public class Products : ViewComponent
    {
        public IViewComponentResult Invoke(string code)
        {
            ViewBag.Coupon = code;
            return View();
        }
    }
}
