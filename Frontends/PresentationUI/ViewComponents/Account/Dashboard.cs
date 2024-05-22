using Microsoft.AspNetCore.Mvc;

namespace PresentationUI.ViewComponents.Account
{
    public class Dashboard : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
