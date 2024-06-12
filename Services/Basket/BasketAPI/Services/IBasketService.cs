using BasketAPI.Dtos;

namespace BasketAPI.Services
{
    public interface IBasketService
    {
        Task<BasketTotalDto> GetBasketAsync(string id);
        Task SaveBasketAsync(BasketTotalDto basket);
        Task DeleteBasketAsync(string id);
        Task<int> GetBasketCountAsync(string id);
    }
}
