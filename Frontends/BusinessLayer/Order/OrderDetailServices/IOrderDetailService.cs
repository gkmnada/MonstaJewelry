using DtoLayer.OrderDto.OrderDetailDto;

namespace BusinessLayer.Order.OrderDetailServices
{
    public interface IOrderDetailService
    {
        Task<GetOrderDetailDto> GetOrderDetailAsync(string id);
    }
}
