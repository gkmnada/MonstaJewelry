using DtoLayer.OrderDto.OrderAddressDto;

namespace BusinessLayer.Order.OrderAddressServices
{
    public interface IOrderAddressService
    {
        Task<GetOrderAddressDto> GetOrderAddressAsync(string id);
    }
}
