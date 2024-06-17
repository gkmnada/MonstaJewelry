using CatalogAPI.Dtos.FooterDto;
using CatalogAPI.Services.FooterServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CatalogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FooterController : ControllerBase
    {
        private readonly IFooterService _footerService;

        public FooterController(IFooterService footerService)
        {
            _footerService = footerService;
        }

        [HttpGet]
        public async Task<IActionResult> ListFooter()
        {
            var values = await _footerService.ListFooterAsync();
            return Ok(values);
        }

        [HttpGet("GetFooter")]
        public async Task<IActionResult> GetFooter(string id)
        {
            var value = await _footerService.GetFooterAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFooter(CreateFooterDto createFooterDto)
        {
            await _footerService.CreateFooterAsync(createFooterDto);
            return Ok("Başarılı");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFooter(UpdateFooterDto updateFooterDto)
        {
            await _footerService.UpdateFooterAsync(updateFooterDto);
            return Ok("Başarılı");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteFooter(string id)
        {
            await _footerService.DeleteFooterAsync(id);
            return Ok("Başarılı");
        }

        [HttpGet("ListFooterWithCategory")]
        public async Task<IActionResult> ListFooterWithCategory()
        {
            var values = await _footerService.ListFooterWithCategoryAsync();
            return Ok(values);
        }
    }
}
