using CatalogAPI.Services.StatisticServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CatalogAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticController : ControllerBase
    {
        private readonly IStatisticService _statisticService;

        public StatisticController(IStatisticService statisticService)
        {
            _statisticService = statisticService;
        }

        [HttpGet("GetCategoryCount")]
        public async Task<IActionResult> GetCategoryCountAsync()
        {
            var categoryCount = await _statisticService.GetCategoryCountAsync();
            return Ok(categoryCount);
        }

        [HttpGet("GetProductCount")]
        public async Task<IActionResult> GetProductCountAsync()
        {
            var productCount = await _statisticService.GetProductCountAsync();
            return Ok(productCount);
        }

        [HttpGet("GetProductCountByCategory")]
        public async Task<IActionResult> GetProductCountByCategoryAsync()
        {
            var productCountByCategory = await _statisticService.GetProductCountByCategoryAsync();
            return Ok(productCountByCategory);
        }
    }
}
