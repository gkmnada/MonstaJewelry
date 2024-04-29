using BusinessLayer.Catalog.BannerServices;
using Microsoft.AspNetCore.Mvc;

namespace PresentationUI.ViewComponents.Home
{
    public class Banner : ViewComponent
    {
        private readonly IBannerService _bannerService;

        public Banner(IBannerService bannerService)
        {
            _bannerService = bannerService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _bannerService.ListBannerWithCategoryAsync();
            return View(values);
        }
    }
}
