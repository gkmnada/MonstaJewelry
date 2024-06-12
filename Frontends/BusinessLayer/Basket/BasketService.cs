using DtoLayer.BasketDto;
using System.Net.Http.Json;

namespace BusinessLayer.Basket
{
    public class BasketService : IBasketService
    {
        private readonly HttpClient _httpClient;

        public BasketService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task AddBasketItemAsync(BasketItemDto basketItemDto)
        {
            var values = await GetBasketAsync();

            if (values != null)
            {
                if (!values.BasketItem.Any(x => x.ProductID == basketItemDto.ProductID))
                {
                    values.BasketItem.Add(basketItemDto);
                }
                else
                {
                    values = new BasketTotalDto();
                    values.BasketItem.Add(basketItemDto);
                }
            }
            await SaveBasketAsync(values);
        }

        public async Task DeleteBasketAsync()
        {
            var values = await GetBasketAsync();
            values.BasketItem.Clear();
            await SaveBasketAsync(values);
        }

        public async Task<BasketTotalDto> GetBasketAsync()
        {
            var responseMessage = await _httpClient.GetAsync("basket");
            var values = await responseMessage.Content.ReadFromJsonAsync<BasketTotalDto>();
            return values;
        }

        public async Task<int> GetBasketCountAsync()
        {
            var responseMessage = await _httpClient.GetAsync("basket/getbasketcount");
            var values = await responseMessage.Content.ReadFromJsonAsync<int>();
            return values;
        }

        public async Task<bool> RemoveBasketItemAsync(string id)
        {
            var values = await GetBasketAsync();
            var deletedItem = values.BasketItem.FirstOrDefault(x => x.ProductID == id);
            var result = values.BasketItem.Remove(deletedItem);
            await SaveBasketAsync(values);
            return true;
        }

        public async Task SaveBasketAsync(BasketTotalDto basketTotalDto)
        {
            await _httpClient.PostAsJsonAsync("basket", basketTotalDto);
        }
    }
}
