using DtoLayer.CatalogDto.BannerDto;
using System.Net.Http.Json;

namespace BusinessLayer.Catalog.BannerServices
{
    public class BannerService : IBannerService
    {
        private readonly HttpClient _httpClient;

        public BannerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateBannerAsync(CreateBannerDto createBannerDto)
        {
            await _httpClient.PostAsJsonAsync("banner", createBannerDto);
        }

        public async Task DeleteBannerAsync(string id)
        {
            await _httpClient.DeleteAsync("banner?id=" + id);
        }

        public async Task<GetBannerDto> GetBannerAsync(string id)
        {
            var response = await _httpClient.GetAsync("banner/getbanner?id=" + id);
            return await response.Content.ReadFromJsonAsync<GetBannerDto>();
        }

        public async Task<List<ResultBannerDto>> ListBannerAsync()
        {
            var response = await _httpClient.GetAsync("banner");
            return await response.Content.ReadFromJsonAsync<List<ResultBannerDto>>();
        }

        public async Task<List<ResultBannerWithCategoryDto>> ListBannerWithCategoryAsync()
        {
            var response = await _httpClient.GetAsync("banner/listbannerwithcategory");
            return await response.Content.ReadFromJsonAsync<List<ResultBannerWithCategoryDto>>();
        }

        public async Task UpdateBannerAsync(UpdateBannerDto updateBannerDto)
        {
            await _httpClient.PutAsJsonAsync("banner", updateBannerDto);
        }
    }
}
