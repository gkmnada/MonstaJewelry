using DtoLayer.CargoCompanyDto;

namespace BusinessLayer.Abstract
{
    public interface ICargoCompanyService
    {
        Task<List<ResultCargoCompanyDto>> itemListCargoCompanyAsync();
        Task itemCreateCargoCompanyAsync(CreateCargoCompanyDto createCargoCompanyDto);
        Task itemUpdateCargoCompanyAsync(UpdateCargoCompanyDto updateCargoCompanyDto);
        Task itemDeleteCargoCompanyAsync(int id);
        Task<GetCargoCompanyDto> itemGetCargoCompanyAsync(int id);
    }
}
