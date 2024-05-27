using Microsoft.AspNetCore.Mvc;

namespace PresentationUI.Areas.Administrator.ViewComponents._AdminLayout
{
    public class _AdminSidebar : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
