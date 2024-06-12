using DtoLayer.BasketDto;

namespace BusinessLayer.Basket
{
    public interface IBasketService
    {
        Task<BasketTotalDto> GetBasketAsync();
        Task SaveBasketAsync(BasketTotalDto basketTotalDto);
        Task DeleteBasketAsync();
        Task AddBasketItemAsync(BasketItemDto basketItemDto);
        Task<bool> RemoveBasketItemAsync(string id);
        Task<int> GetBasketCountAsync();
    }
}
