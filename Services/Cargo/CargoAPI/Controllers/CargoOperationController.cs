using BusinessLayer.Abstract;
using DtoLayer.CargoOperationDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CargoAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoOperationController : ControllerBase
    {
        private readonly ICargoOperationService _cargoOperationService;

        public CargoOperationController(ICargoOperationService cargoOperationService)
        {
            _cargoOperationService = cargoOperationService;
        }

        [HttpGet]
        public async Task<IActionResult> ListCargoOperation()
        {
            var values = await _cargoOperationService.itemListCargoOperationAsync();
            return Ok(values);
        }

        [HttpGet("GetCargoOperation")]
        public async Task<IActionResult> GetCargoOperation(int id)
        {
            var values = await _cargoOperationService.itemGetCargoOperationAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCargoOperation(CreateCargoOperationDto createCargoOperationDto)
        {
            await _cargoOperationService.itemCreateCargoOperationAsync(createCargoOperationDto);
            return Ok("Başarılı");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCargoOperation(UpdateCargoOperationDto updateCargoOperationDto)
        {
            await _cargoOperationService.itemUpdateCargoOperationAsync(updateCargoOperationDto);
            return Ok("Başarılı");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCargoOperation(int id)
        {
            await _cargoOperationService.itemDeleteCargoOperationAsync(id);
            return Ok("Başarılı");
        }
    }
}
