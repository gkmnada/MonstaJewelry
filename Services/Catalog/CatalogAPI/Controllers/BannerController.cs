using CatalogAPI.Dtos.BannerDto;
using CatalogAPI.Services.BannerServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CatalogAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BannerController : ControllerBase
    {
        private readonly IBannerService _bannerService;

        public BannerController(IBannerService bannerService)
        {
            _bannerService = bannerService;
        }

        [HttpGet]
        public async Task<IActionResult> ListBanner()
        {
            var values = await _bannerService.ListBannerAsync();
            return Ok(values);
        }

        [HttpGet("GetBanner")]
        public async Task<IActionResult> GetBanner(string id)
        {
            var values = await _bannerService.GetBannerAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBanner(CreateBannerDto createBannerDto)
        {
            await _bannerService.CreateBannerAsync(createBannerDto);
            return Ok("Başarılı");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBanner(UpdateBannerDto updateBannerDto)
        {
            await _bannerService.UpdateBannerAsync(updateBannerDto);
            return Ok("Başarılı");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBanner(string id)
        {
            await _bannerService.DeleteBannerAsync(id);
            return Ok("Başarılı");
        }

        [HttpGet("ListBannerWithCategory")]
        public async Task<IActionResult> ListBannerWithCategory()
        {
            var values = await _bannerService.ListBannerWithCategoryAsync();
            return Ok(values);
        }
    }
}
