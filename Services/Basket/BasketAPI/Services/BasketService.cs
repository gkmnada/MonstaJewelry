using BasketAPI.Dtos;
using BasketAPI.Settings;
using System.Text.Json;

namespace BasketAPI.Services
{
    public class BasketService : IBasketService
    {
        private readonly RedisService _redisService;

        public BasketService(RedisService redisService)
        {
            _redisService = redisService;
        }

        public async Task DeleteBasketAsync(string id)
        {
            await _redisService.GetDb().KeyDeleteAsync(id);
        }

        public async Task<BasketTotalDto> GetBasketAsync(string id)
        {
            var existBasket = await _redisService.GetDb().StringGetAsync(id);
            return JsonSerializer.Deserialize<BasketTotalDto>(existBasket);
        }

        public async Task SaveBasketAsync(BasketTotalDto basket)
        {
            await _redisService.GetDb().StringSetAsync(basket.UserID, JsonSerializer.Serialize(basket));
        }
    }
}
