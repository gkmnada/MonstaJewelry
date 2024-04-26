using DtoLayer.IdentityDto.LoginDto;
using Microsoft.AspNetCore.Mvc;
using PresentationUI.Services.Abstract;

namespace PresentationUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly IIdentityService _identityService;

        public LoginController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginDto loginDto)
        {
            await _identityService.SignIn(loginDto);
            return RedirectToAction("Index", "Home");
        }
    }
}
