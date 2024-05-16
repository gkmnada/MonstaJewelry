using Microsoft.AspNetCore.Mvc;

namespace PresentationUI.ViewComponents.Order
{
    public class OrderDetail : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
