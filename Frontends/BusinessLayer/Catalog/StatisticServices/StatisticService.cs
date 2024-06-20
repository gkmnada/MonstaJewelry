using DtoLayer.CatalogDto.StatisticDto;
using System.Net.Http.Json;

namespace BusinessLayer.Catalog.StatisticServices
{
    public class StatisticService : IStatisticService
    {
        private readonly HttpClient _client;

        public StatisticService(HttpClient client)
        {
            _client = client;
        }

        public async Task<long> GetCategoryCountAsync()
        {
            var response = await _client.GetAsync("statistic/getcategorycount");
            return await response.Content.ReadFromJsonAsync<long>();
        }

        public async Task<long> GetProductCountAsync()
        {
            var response = await _client.GetAsync("statistic/getproductcount");
            return await response.Content.ReadFromJsonAsync<long>();
        }

        public async Task<List<GetProductCountByCategoryDto>> GetProductCountByCategoryAsync()
        {
            var response = await _client.GetAsync("statistic/getproductcountbycategory");
            return await response.Content.ReadFromJsonAsync<List<GetProductCountByCategoryDto>>();
        }
    }
}
