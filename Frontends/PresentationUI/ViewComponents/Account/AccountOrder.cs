using Microsoft.AspNetCore.Mvc;

namespace PresentationUI.ViewComponents.Account
{
    public class AccountOrder : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
