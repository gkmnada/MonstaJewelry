using BusinessLayer.Catalog.SubscribeServices;
using DtoLayer.CatalogDto.SubscribeDto;
using Microsoft.AspNetCore.Mvc;

namespace PresentationUI.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class SubscribeController : Controller
    {
        private readonly ISubscribeService _subscribeService;

        public SubscribeController(ISubscribeService subscribeService)
        {
            _subscribeService = subscribeService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _subscribeService.ListSubscribeAsync();
            return View(values);
        }

        public async Task<IActionResult> DeleteSubscribe(string id)
        {
            await _subscribeService.DeleteSubscribeAsync(id);
            return RedirectToAction("Index", "Subscribe", new { area = "Administrator" });
        }
    }
}
