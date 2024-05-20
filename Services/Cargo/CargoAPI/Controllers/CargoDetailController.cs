using BusinessLayer.Abstract;
using DtoLayer.CargoDetailDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CargoAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoDetailController : ControllerBase
    {
        private readonly ICargoDetailService _cargoDetailService;

        public CargoDetailController(ICargoDetailService cargoDetailService)
        {
            _cargoDetailService = cargoDetailService;
        }

        [HttpGet]
        public async Task<IActionResult> ListCargoDetail()
        {
            var values = await _cargoDetailService.itemListCargoDetailAsync();
            return Ok(values);
        }

        [HttpGet("GetCargoDetail")]
        public async Task<IActionResult> GetCargoDetail(int id)
        {
            var values = await _cargoDetailService.itemGetCargoDetailAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCargoDetail(CreateCargoDetailDto createCargoDetailDto)
        {
            await _cargoDetailService.itemCreateCargoDetailAsync(createCargoDetailDto);
            return Ok("Başarılı");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCargoDetail(UpdateCargoDetailDto updateCargoDetailDto)
        {
            await _cargoDetailService.itemUpdateCargoDetailAsync(updateCargoDetailDto);
            return Ok("Başarılı");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCargoDetail(int id)
        {
            await _cargoDetailService.itemDeleteCargoDetailAsync(id);
            return Ok("Başarılı");
        }
    }
}
