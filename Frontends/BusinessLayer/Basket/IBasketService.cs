using DtoLayer.BasketDto;

namespace BusinessLayer.Basket
{
    public interface IBasketService
    {
        Task<BasketTotalDto> GetBasketAsync();
        Task SaveBasketAsync(BasketTotalDto basketTotalDto);
        Task DeleteBasketAsync(string id);
        Task AddBasketItemAsync(BasketItemDto basketItemDto);
        Task<bool> RemoveBasketItemAsync(string id);
    }
}
