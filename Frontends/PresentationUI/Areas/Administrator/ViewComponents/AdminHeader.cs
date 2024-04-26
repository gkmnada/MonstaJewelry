using Microsoft.AspNetCore.Mvc;
using PresentationUI.Services.Abstract;

namespace PresentationUI.Areas.Administrator.ViewComponents
{
    public class AdminHeader : ViewComponent
    {
        private readonly IUserService _userService;

        public AdminHeader(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _userService.GetUserInfo();
            return View(values);
        }
    }
}
