using BusinessLayer.Abstract;
using DtoLayer.CargoCustomerDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CargoAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCustomerController : ControllerBase
    {
        private readonly ICargoCustomerService _cargoCustomerService;

        public CargoCustomerController(ICargoCustomerService cargoCustomerService)
        {
            _cargoCustomerService = cargoCustomerService;
        }

        [HttpGet]
        public async Task<IActionResult> ListCargoCustomer()
        {
            var values = await _cargoCustomerService.itemListCargoCustomerAsync();
            return Ok(values);
        }

        [HttpGet("GetCargoCustomer")]
        public async Task<IActionResult> GetCargoCustomer(int id)
        {
            var values = await _cargoCustomerService.itemGetCargoCustomerAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCargoCustomer(CreateCargoCustomerDto createCargoCustomerDto)
        {
            await _cargoCustomerService.itemCreateCargoCustomerAsync(createCargoCustomerDto);
            return Ok("Başarılı");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCargoCustomer(UpdateCargoCustomerDto updateCargoCustomerDto)
        {
            await _cargoCustomerService.itemUpdateCargoCustomerAsync(updateCargoCustomerDto);
            return Ok("Başarılı");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCargoCustomer(int id)
        {
            await _cargoCustomerService.itemDeleteCargoCustomerAsync(id);
            return Ok("Başarılı");
        }
    }
}
