using DtoLayer.CargoCustomerDto;

namespace DataAccessLayer.Abstract
{
    public interface ICargoCustomerDal
    {
        Task<List<ResultCargoCustomerDto>> ListCargoCustomerAsync();
        Task CreateCargoCustomerAsync(CreateCargoCustomerDto createCargoCustomerDto);
        Task UpdateCargoCustomerAsync(UpdateCargoCustomerDto updateCargoCustomerDto);
        Task DeleteCargoCustomerAsync(int id);
        Task<GetCargoCustomerDto> GetCargoCustomerAsync(int id);
    }
}
