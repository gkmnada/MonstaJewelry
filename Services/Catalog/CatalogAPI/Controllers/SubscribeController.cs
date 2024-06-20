using CatalogAPI.Dtos.SubscribeDto;
using CatalogAPI.Services.SubscribeServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CatalogAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribeController : ControllerBase
    {
        private readonly ISubscribeService _subscribeService;

        public SubscribeController(ISubscribeService subscribeService)
        {
            _subscribeService = subscribeService;
        }

        [HttpGet]
        public async Task<IActionResult> ListSubscribe()
        {
            var values = await _subscribeService.ListSubscribeAsync();
            return Ok(values);
        }

        [HttpGet("GetSubscribe")]
        public async Task<IActionResult> GetSubscribe(string id)
        {
            var value = await _subscribeService.GetSubscribeAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSubscribe(CreateSubscribeDto createSubscribeDto)
        {
            await _subscribeService.CreateSubscribeAsync(createSubscribeDto);
            return Ok("Başarılı");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSubscribe(UpdateSubscribeDto updateSubscribeDto)
        {
            await _subscribeService.UpdateSubscribeAsync(updateSubscribeDto);
            return Ok("Başarılı");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteSubscribe(string id)
        {
            await _subscribeService.DeleteSubscribeAsync(id);
            return Ok("Başarılı");
        }
    }
}
