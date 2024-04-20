using Microsoft.AspNetCore.Mvc;

namespace PresentationUI.Areas.Administrator.ViewComponents
{
    public class AdminHeader : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
