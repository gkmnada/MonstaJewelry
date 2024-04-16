using Microsoft.AspNetCore.Mvc;

namespace PresentationUI.ViewComponents.Layout
{
    public class Footer : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
