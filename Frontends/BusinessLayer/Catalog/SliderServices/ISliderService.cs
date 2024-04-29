using DtoLayer.CatalogDto.SliderDto;

namespace BusinessLayer.Catalog.SliderServices
{
    public interface ISliderService
    {
        Task<List<ResultSliderDto>> ListSliderAsync();
        Task CreateSliderAsync(CreateSliderDto createSliderDto);
        Task UpdateSliderAsync(UpdateSliderDto updateSliderDto);
        Task DeleteSliderAsync(string id);
        Task<GetSliderDto> GetSliderAsync(string id);
    }
}
