using DtoLayer.CatalogDto.ExclusiveSelectionsDto;

namespace BusinessLayer.Catalog.ExclusiveSelectionsServices
{
    public interface IExclusiveSelectionsService
    {
        Task<List<ResultExclusiveSelectionsDto>> ListExclusiveSelectionsAsync();
        Task CreateExclusiveSelectionsAsync(CreateExclusiveSelectionsDto createExclusiveSelectionsDto);
        Task UpdateExclusiveSelectionsAsync(UpdateExclusiveSelectionsDto updateExclusiveSelectionsDto);
        Task DeleteExclusiveSelectionsAsync(string id);
        Task<GetExclusiveSelectionsDto> GetExclusiveSelectionsAsync(string id);
    }
}
