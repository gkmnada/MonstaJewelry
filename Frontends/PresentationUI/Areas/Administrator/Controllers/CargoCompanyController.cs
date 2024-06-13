using BusinessLayer.Cargo.CargoCompanyServices;
using DtoLayer.CargoDto.CargoCompanyDto;
using Microsoft.AspNetCore.Mvc;
using PresentationUI.Areas.Administrator.Models;

namespace PresentationUI.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class CargoCompanyController : Controller
    {
        private readonly ICargoCompanyService _cargoCompanyService;

        public CargoCompanyController(ICargoCompanyService cargoCompanyService)
        {
            _cargoCompanyService = cargoCompanyService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _cargoCompanyService.ListCargoCompanyAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateCompany()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCompany(CreateCargoCompanyDto createCargoCompanyDto)
        {
            await _cargoCompanyService.CreateCargoCompanyAsync(createCargoCompanyDto);
            return RedirectToAction("Index", "CargoCompany", new { area = "Administrator" });
        }

        public async Task<IActionResult> DeleteCompany(int id)
        {
            await _cargoCompanyService.DeleteCargoCompanyAsync(id);
            return RedirectToAction("Index", "CargoCompany", new { area = "Administrator" });
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCompany(int id)
        {
            var value = await _cargoCompanyService.GetCargoCompanyAsync(id);

            var cargoViewModel = new CargoViewModel
            {
                GetCargoCompanyDto = value
            };
            return View(cargoViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCompany(UpdateCargoCompanyDto updateCargoCompanyDto)
        {
            await _cargoCompanyService.UpdateCargoCompanyAsync(updateCargoCompanyDto);
            return RedirectToAction("Index", "CargoCompany", new { area = "Administrator" });
        }
    }
}
