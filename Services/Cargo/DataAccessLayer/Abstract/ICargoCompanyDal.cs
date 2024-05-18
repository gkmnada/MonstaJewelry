using DtoLayer.CargoCompanyDto;

namespace DataAccessLayer.Abstract
{
    public interface ICargoCompanyDal
    {
        Task<List<ResultCargoCompanyDto>> ListCargoCompanyAsync();
        Task CreateCargoCompanyAsync(CreateCargoCompanyDto createCargoCompanyDto);
        Task UpdateCargoCompanyAsync(UpdateCargoCompanyDto updateCargoCompanyDto);
        Task DeleteCargoCompanyAsync(int id);
        Task<GetCargoCompanyDto> GetCargoCompanyAsync(int id);
    }
}
