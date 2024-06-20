using BusinessLayer.Catalog.SubscribeServices;
using DtoLayer.CatalogDto.SubscribeDto;
using Microsoft.AspNetCore.Mvc;

namespace PresentationUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISubscribeService _subscribeService;

        public HomeController(ISubscribeService subscribeService)
        {
            _subscribeService = subscribeService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateSubscribe(CreateSubscribeDto createSubscribeDto)
        {
            if (ModelState.IsValid)
            {
                createSubscribeDto.Status = true;
                await _subscribeService.CreateSubscribeAsync(createSubscribeDto);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
