using CatalogAPI.Dtos.ExclusiveSelectionsDto;
using CatalogAPI.Services.ExclusiveSelectionsServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CatalogAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ExclusiveSelectionsController : ControllerBase
    {
        private readonly IExclusiveSelectionsService _exclusiveSelectionsService;

        public ExclusiveSelectionsController(IExclusiveSelectionsService exclusiveSelectionsService)
        {
            _exclusiveSelectionsService = exclusiveSelectionsService;
        }

        [HttpGet]
        public async Task<IActionResult> ListExclusiveSelections()
        {
            var values = await _exclusiveSelectionsService.ListExclusiveSelectionsAsync();
            return Ok(values);
        }

        [HttpGet("GetExclusiveSelections")]
        public async Task<IActionResult> GetExclusiveSelections(string id)
        {
            var value = await _exclusiveSelectionsService.GetExclusiveSelectionsAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateExclusiveSelections(CreateExclusiveSelectionsDto createExclusiveSelectionsDto)
        {
            await _exclusiveSelectionsService.CreateExclusiveSelectionsAsync(createExclusiveSelectionsDto);
            return Ok("Başarılı");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateExclusiveSelections(UpdateExclusiveSelectionsDto updateExclusiveSelectionsDto)
        {
            await _exclusiveSelectionsService.UpdateExclusiveSelectionsAsync(updateExclusiveSelectionsDto);
            return Ok("Başarılı");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteExclusiveSelections(string id)
        {
            await _exclusiveSelectionsService.DeleteExclusiveSelectionsAsync(id);
            return Ok("Başarılı");
        }
    }
}
