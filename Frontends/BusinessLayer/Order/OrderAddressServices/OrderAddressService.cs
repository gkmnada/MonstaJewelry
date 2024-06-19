using DtoLayer.OrderDto.OrderAddressDto;
using System.Net.Http.Json;

namespace BusinessLayer.Order.OrderAddressServices
{
    public class OrderAddressService : IOrderAddressService
    {
        private readonly HttpClient _httpClient;

        public OrderAddressService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<GetOrderAddressDto> GetOrderAddressAsync(string id)
        {
            var response = await _httpClient.GetAsync("orderaddress?id=" + id);
            var values = await response.Content.ReadFromJsonAsync<GetOrderAddressDto>();
            return values;
        }
    }
}
