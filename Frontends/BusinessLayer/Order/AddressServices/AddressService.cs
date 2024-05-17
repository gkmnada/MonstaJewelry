using DtoLayer.OrderDto.AddressDto;
using System.Net.Http.Json;

namespace BusinessLayer.Order.AddressServices
{
    public class AddressService : IAddressService
    {
        private readonly HttpClient _httpClient;

        public AddressService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateAddressAsync(CreateAddressDto createAddressDto)
        {
            await _httpClient.PostAsJsonAsync("address", createAddressDto);
        }

        public async Task<GetAddressDto> GetAddressAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("address/getaddress?id=" + id);
            return await responseMessage.Content.ReadFromJsonAsync<GetAddressDto>();
        }

        public async Task<List<ResultAddressDto>> ListAddressByUserAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("address/getaddressbyuser?id=" + id);
            return await responseMessage.Content.ReadFromJsonAsync<List<ResultAddressDto>>();
        }
    }
}
