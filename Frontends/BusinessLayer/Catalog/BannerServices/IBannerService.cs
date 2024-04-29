using DtoLayer.CatalogDto.BannerDto;

namespace BusinessLayer.Catalog.BannerServices
{
    public interface IBannerService
    {
        Task<List<ResultBannerDto>> ListBannerAsync();
        Task CreateBannerAsync(CreateBannerDto createBannerDto);
        Task UpdateBannerAsync(UpdateBannerDto updateBannerDto);
        Task DeleteBannerAsync(string id);
        Task<GetBannerDto> GetBannerAsync(string id);
        Task<List<ResultBannerWithCategoryDto>> ListBannerWithCategoryAsync();
    }
}
