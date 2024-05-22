using Microsoft.AspNetCore.Mvc;

namespace PresentationUI.ViewComponents.Account
{
    public class AccountAddress : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
