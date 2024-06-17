using CatalogAPI.Dtos.FooterDto;

namespace CatalogAPI.Services.FooterServices
{
    public interface IFooterService
    {
        Task<List<ResultFooterDto>> ListFooterAsync();
        Task CreateFooterAsync(CreateFooterDto createFooterDto);
        Task UpdateFooterAsync(UpdateFooterDto updateFooterDto);
        Task DeleteFooterAsync(string id);
        Task<GetFooterDto> GetFooterAsync(string id);
        Task<List<ResultFooterWithCategoryDto>> ListFooterWithCategoryAsync();
    }
}
