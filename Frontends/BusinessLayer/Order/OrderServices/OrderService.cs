using DtoLayer.OrderDto.OrderDto;
using System.Net.Http.Json;

namespace BusinessLayer.Order.OrderServices
{
    public class OrderService : IOrderService
    {
        private readonly HttpClient httpClient;

        public OrderService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task CreateOrderAsync(CreateOrderDto createOrderDto)
        {
            await httpClient.PostAsJsonAsync("order", createOrderDto);
        }

        public async Task DeleteOrderAsync(string id)
        {
            await httpClient.DeleteAsync("order?id=" + id);
        }

        public async Task<GetOrderDto> GetOrderAsync(string id)
        {
            var response = await httpClient.GetAsync("order/getorder?id=" + id);
            return await response.Content.ReadFromJsonAsync<GetOrderDto>();
        }

        public async Task<List<ResultOrderDto>> ListOrderAsync()
        {
            var response = await httpClient.GetAsync("order");
            return await response.Content.ReadFromJsonAsync<List<ResultOrderDto>>();
        }

        public async Task<List<ResultOrderByUserDto>> ListOrderByUserAsync(string id)
        {
            var response = await httpClient.GetAsync("order/listorderbyuser?id=" + id);
            return await response.Content.ReadFromJsonAsync<List<ResultOrderByUserDto>>();
        }

        public async Task UpdateOrderAsync(UpdateOrderDto updateOrderDto)
        {
            await httpClient.PutAsJsonAsync("order", updateOrderDto);
        }
    }
}
