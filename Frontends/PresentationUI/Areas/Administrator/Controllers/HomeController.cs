using BusinessLayer.Catalog.StatisticServices;
using Microsoft.AspNetCore.Mvc;

namespace PresentationUI.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class HomeController : Controller
    {
        private readonly IStatisticService _statisticService;

        public HomeController(IStatisticService statisticService)
        {
            _statisticService = statisticService;
        }

        public async Task<IActionResult> Index()
        {
            var totalProducts = await _statisticService.GetProductCountAsync();
            var productCount = await _statisticService.GetProductCountByCategoryAsync();

            var bracelet = productCount.Where(x => x.CategoryName == "Bileklikler").Select(x => x.ProductCount).FirstOrDefault();
            var ring = productCount.Where(x => x.CategoryName == "Yüzükler").Select(x => x.ProductCount).FirstOrDefault();
            var necklace = productCount.Where(x => x.CategoryName == "Kolyeler").Select(x => x.ProductCount).FirstOrDefault();
            var charm = productCount.Where(x => x.CategoryName == "Charm'lar").Select(x => x.ProductCount).FirstOrDefault();
            var earring = productCount.Where(x => x.CategoryName == "Küpeler").Select(x => x.ProductCount).FirstOrDefault();

            ViewBag.TotalProducts = totalProducts;
            ViewBag.Bracelet = bracelet;
            ViewBag.Ring = ring;
            ViewBag.Other = necklace + charm + earring;

            return View();
        }
    }
}
