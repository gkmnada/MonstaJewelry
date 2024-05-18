using DtoLayer.CargoCustomerDto;

namespace BusinessLayer.Abstract
{
    public interface ICargoCustomerService
    {
        Task<List<ResultCargoCustomerDto>> itemListCargoCustomerAsync();
        Task itemCreateCargoCustomerAsync(CreateCargoCustomerDto createCargoCustomerDto);
        Task itemUpdateCargoCustomerAsync(UpdateCargoCustomerDto updateCargoCustomerDto);
        Task itemDeleteCargoCustomerAsync(int id);
        Task<GetCargoCustomerDto> itemGetCargoCustomerAsync(int id);
    }
}
