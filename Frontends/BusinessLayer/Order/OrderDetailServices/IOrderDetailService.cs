using DtoLayer.OrderDto.OrderDetailDto;

namespace BusinessLayer.Order.OrderDetailServices
{
    public interface IOrderDetailService
    {
        Task<List<ResultOrderDetailDto>> ListOrderDetailAsync(string id);
        Task<GetOrderDetailDto> GetOrderDetailAsync(string id);
    }
}
