using DtoLayer.CargoDetailDto;

namespace BusinessLayer.Abstract
{
    public interface ICargoDetailService
    {
        Task<List<ResultCargoDetailDto>> itemListCargoDetailAsync();
        Task itemCreateCargoDetailAsync(CreateCargoDetailDto createCargoDetailDto);
        Task itemUpdateCargoDetailAsync(UpdateCargoDetailDto updateCargoDetailDto);
        Task itemDeleteCargoDetailAsync(int id);
        Task<GetCargoDetailDto> itemGetCargoDetailAsync(int id);
    }
}
