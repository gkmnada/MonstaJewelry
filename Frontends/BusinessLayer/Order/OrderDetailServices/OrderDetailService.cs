using DtoLayer.OrderDto.OrderDetailDto;
using System.Net.Http.Json;

namespace BusinessLayer.Order.OrderDetailServices
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly HttpClient _httpClient;

        public OrderDetailService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<GetOrderDetailDto> GetOrderDetailAsync(string id)
        {
            var response = await _httpClient.GetAsync("orderdetail/getorderdetail?id=" + id);
            var values = await response.Content.ReadFromJsonAsync<GetOrderDetailDto>();
            return values;
        }

        public async Task<List<ResultOrderDetailDto>> ListOrderDetailAsync(string id)
        {
            var response = await _httpClient.GetAsync("orderdetail?id=" + id);
            var values = await response.Content.ReadFromJsonAsync<List<ResultOrderDetailDto>>();
            return values;
        }
    }
}
