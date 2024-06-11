using DtoLayer.CargoDto.CargoCompanyDto;

namespace BusinessLayer.Cargo.CargoCompanyServices
{
    public interface ICargoCompanyService
    {
        Task<List<ResultCargoCompanyDto>> ListCargoCompanyAsync();
        Task CreateCargoCompanyAsync(CreateCargoCompanyDto createCargoCompanyDto);
        Task UpdateCargoCompanyAsync(UpdateCargoCompanyDto updateCargoCompanyDto);
        Task DeleteCargoCompanyAsync(int id);
        Task<GetCargoCompanyDto> GetCargoCompanyAsync(int id);
    }
}
