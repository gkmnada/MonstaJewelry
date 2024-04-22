using DtoLayer.CatalogDto.CategoryDto;

namespace BusinessLayer.Catalog.CategoryServices
{
    public interface ICategoryService
    {
        Task<List<ResultCategoryDto>> ListCategoryAsync();
        Task CreateCategoryAsync(CreateCategoryDto createCategoryDto);
        Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto);
        Task DeleteCategoryAsync(string id);
        Task<GetCategoryDto> GetCategoryAsync(string id);
    }
}
