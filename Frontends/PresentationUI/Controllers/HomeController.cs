using Microsoft.AspNetCore.Mvc;
using PresentationUI.Services.Abstract;

namespace PresentationUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService _userService;

        public HomeController(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            var value = await _userService.GetUserInfo();
            return View(value);
        }
    }
}
