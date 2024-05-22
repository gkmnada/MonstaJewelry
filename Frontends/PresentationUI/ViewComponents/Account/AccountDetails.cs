using Microsoft.AspNetCore.Mvc;

namespace PresentationUI.ViewComponents.Account
{
    public class AccountDetails : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
