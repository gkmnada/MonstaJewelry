using BusinessLayer.Abstract;
using DtoLayer.CargoCompanyDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CargoAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCompanyController : ControllerBase
    {
        private readonly ICargoCompanyService _cargoCompanyService;

        public CargoCompanyController(ICargoCompanyService cargoCompanyService)
        {
            _cargoCompanyService = cargoCompanyService;
        }

        [HttpGet]
        public async Task<IActionResult> ListCargoCompany()
        {
            var values = await _cargoCompanyService.itemListCargoCompanyAsync();
            return Ok(values);
        }

        [HttpGet("GetCargoCompany")]
        public async Task<IActionResult> GetCargoCompany(int id)
        {
            var values = await _cargoCompanyService.itemGetCargoCompanyAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> AddCargoCompany(CreateCargoCompanyDto createCargoCompanyDto)
        {
            await _cargoCompanyService.itemCreateCargoCompanyAsync(createCargoCompanyDto);
            return Ok("Başarılı");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCargoCompany(UpdateCargoCompanyDto updateCargoCompanyDto)
        {
            await _cargoCompanyService.itemUpdateCargoCompanyAsync(updateCargoCompanyDto);
            return Ok("Başarılı");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCargoCompany(int id)
        {
            await _cargoCompanyService.itemDeleteCargoCompanyAsync(id);
            return Ok("Başarılı");
        }
    }
}
