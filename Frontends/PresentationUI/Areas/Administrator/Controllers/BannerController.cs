using BusinessLayer.Catalog.BannerServices;
using BusinessLayer.Catalog.CategoryServices;
using DtoLayer.CatalogDto.BannerDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PresentationUI.Areas.Administrator.Models;

namespace PresentationUI.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class BannerController : Controller
    {
        private readonly IBannerService _bannerService;
        private readonly ICategoryService _categoryService;

        public BannerController(IBannerService bannerService, ICategoryService categoryService)
        {
            _bannerService = bannerService;
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _bannerService.ListBannerWithCategoryAsync();
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> CreateBanner()
        {
            var values = await _categoryService.ListCategoryAsync();
            List<SelectListItem> listCategory = (from x in values
                                                 select new SelectListItem
                                                 {
                                                     Text = x.CategoryName,
                                                     Value = x.CategoryID
                                                 }).ToList();
            ViewBag.CategoryList = listCategory;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBanner(CreateBannerDto createBannerDto)
        {
            await _bannerService.CreateBannerAsync(createBannerDto);
            return RedirectToAction("Index", "Banner", new { area = "Administrator" });
        }

        [HttpGet]
        public async Task<IActionResult> UpdateBanner(string id)
        {
            var values = await _categoryService.ListCategoryAsync();
            List<SelectListItem> listCategory = (from x in values
                                                 select new SelectListItem
                                                 {
                                                     Text = x.CategoryName,
                                                     Value = x.CategoryID
                                                 }).ToList();
            ViewBag.CategoryList = listCategory;

            var banner = await _bannerService.GetBannerAsync(id);

            var bannerViewModel = new BannerViewModel
            {
                GetBannerDto = banner
            };
            ViewBag.SelectedCategory = banner.CategoryID;

            return View(bannerViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBanner(UpdateBannerDto updateBannerDto)
        {
            await _bannerService.UpdateBannerAsync(updateBannerDto);
            return RedirectToAction("Index", "Banner", new { area = "Administrator" });
        }

        public async Task<IActionResult> DeleteBanner(string id)
        {
            await _bannerService.DeleteBannerAsync(id);
            return RedirectToAction("Index", "Banner", new { area = "Administrator" });
        }
    }
}
