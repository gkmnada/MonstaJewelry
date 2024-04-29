using BusinessLayer.Catalog.SliderServices;
using Microsoft.AspNetCore.Mvc;

namespace PresentationUI.ViewComponents.Home
{
    public class Slider : ViewComponent
    {
        private readonly ISliderService _sliderService;

        public Slider(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _sliderService.ListSliderAsync();
            return View(values);
        }
    }
}
