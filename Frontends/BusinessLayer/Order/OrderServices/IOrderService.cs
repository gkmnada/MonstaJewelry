using DtoLayer.OrderDto.OrderDto;

namespace BusinessLayer.Order.OrderServices
{
    public interface IOrderService
    {
        Task<List<ResultOrderDto>> ListOrderAsync();
        Task CreateOrderAsync(CreateOrderDto createOrderDto);
        Task UpdateOrderAsync(UpdateOrderDto updateOrderDto);
        Task DeleteOrderAsync(string id);
        Task<GetOrderDto> GetOrderAsync(string id);
        Task<List<ResultOrderByUserDto>> ListOrderByUserAsync(string id);
    }
}
