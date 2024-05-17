using DtoLayer.OrderDto.AddressDto;

namespace BusinessLayer.Order.AddressServices
{
    public interface IAddressService
    {
        Task CreateAddressAsync(CreateAddressDto createAddressDto);
        Task<List<ResultAddressDto>> ListAddressByUserAsync(string id);
        Task<GetAddressDto> GetAddressAsync(string id);
    }
}
