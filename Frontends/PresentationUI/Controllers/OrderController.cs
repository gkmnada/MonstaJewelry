using BusinessLayer.Order.AddressServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PresentationUI.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IAddressService _addressService;

        public OrderController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        public IActionResult Index(string code)
        {
            ViewBag.Code = code;
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAddress(string id)
        {
            var values = await _addressService.GetAddressAsync(id);
            return Json(values);
        }
    }
}
