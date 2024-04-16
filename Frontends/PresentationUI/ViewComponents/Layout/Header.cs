using Microsoft.AspNetCore.Mvc;

namespace PresentationUI.ViewComponents.Layout
{
    public class Header : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
