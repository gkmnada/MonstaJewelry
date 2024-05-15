using Microsoft.AspNetCore.Mvc;

namespace PresentationUI.ViewComponents.Order
{
    public class Address : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
