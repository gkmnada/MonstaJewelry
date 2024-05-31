using Microsoft.AspNetCore.Mvc;

namespace PresentationUI.ViewComponents.Account
{
    public class AddressDetails : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
