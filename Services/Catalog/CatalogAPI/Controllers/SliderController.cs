using CatalogAPI.Dtos.SliderDto;
using CatalogAPI.Services.SliderServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CatalogAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SliderController : ControllerBase
    {
        private readonly ISliderService _sliderService;

        public SliderController(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }

        [HttpGet]
        public async Task<IActionResult> ListSlider()
        {
            var values = await _sliderService.ListSliderAsync();
            return Ok(values);
        }

        [HttpGet("GetSlider")]
        public async Task<IActionResult> GetSlider(string id)
        {
            var values = await _sliderService.GetSliderAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSlider(CreateSliderDto createSliderDto)
        {
            await _sliderService.CreateSliderAsync(createSliderDto);
            return Ok("Başarılı");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSlider(UpdateSliderDto updateSliderDto)
        {
            await _sliderService.UpdateSliderAsync(updateSliderDto);
            return Ok("Başarılı");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteSlider(string id)
        {
            await _sliderService.DeleteSliderAsync(id);
            return Ok("Başarılı");
        }
    }
}
