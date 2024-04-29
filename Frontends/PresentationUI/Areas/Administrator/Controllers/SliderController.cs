using BusinessLayer.Catalog.SliderServices;
using DtoLayer.CatalogDto.SliderDto;
using Microsoft.AspNetCore.Mvc;
using PresentationUI.Areas.Administrator.Models;

namespace PresentationUI.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class SliderController : Controller
    {
        private readonly ISliderService _sliderService;

        public SliderController(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _sliderService.ListSliderAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateSlider()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateSlider(CreateSliderDto createSliderDto)
        {
            await _sliderService.CreateSliderAsync(createSliderDto);
            return RedirectToAction("Index", "Slider", new { area = "Administrator" });
        }

        [HttpGet]
        public async Task<IActionResult> UpdateSlider(string id)
        {
            var values = await _sliderService.GetSliderAsync(id);

            var sliderViewModel = new SliderViewModel
            {
                GetSliderDto = values
            };

            return View(sliderViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSlider(UpdateSliderDto updateSliderDto)
        {
            await _sliderService.UpdateSliderAsync(updateSliderDto);
            return RedirectToAction("Index", "Slider", new { area = "Administrator" });
        }

        public async Task<IActionResult> DeleteSlider(string id)
        {
            await _sliderService.DeleteSliderAsync(id);
            return RedirectToAction("Index", "Slider", new { area = "Administrator" });
        }
    }
}
