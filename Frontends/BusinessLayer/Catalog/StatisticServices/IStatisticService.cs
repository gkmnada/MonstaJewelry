using DtoLayer.CatalogDto.StatisticDto;

namespace BusinessLayer.Catalog.StatisticServices
{
    public interface IStatisticService
    {
        Task<long> GetCategoryCountAsync();
        Task<long> GetProductCountAsync();
        Task<List<GetProductCountByCategoryDto>> GetProductCountByCategoryAsync();
    }
}
