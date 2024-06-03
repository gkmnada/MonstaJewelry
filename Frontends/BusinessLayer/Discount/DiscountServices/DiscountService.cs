using DtoLayer.DiscountDto.CouponDto;
using System.Net.Http.Json;

namespace BusinessLayer.Discount.DiscountServices
{
    public class DiscountService : IDiscountService
    {
        private readonly HttpClient _httpClient;

        public DiscountService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateCouponAsync(CreateCouponDto createCouponDto)
        {
            await _httpClient.PostAsJsonAsync("discount", createCouponDto);
        }

        public async Task DeleteCouponAsync(int id)
        {
            await _httpClient.DeleteAsync("discount?id=" + id);
        }

        public async Task<GetCouponDto> GetCouponAsync(int id)
        {
            var responseMessage = await _httpClient.GetAsync("discount/getcoupon?id=" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<GetCouponDto>();
            return values;
        }

        public async Task<GetCouponDto> GetCouponCodeAsync(string code)
        {
            var responseMessage = await _httpClient.GetAsync("discount/getcouponcode?code=" + code);
            var values = await responseMessage.Content.ReadFromJsonAsync<GetCouponDto>();
            return values;
        }

        public async Task<List<ResultCouponDto>> ListCouponAsync()
        {
            var responseMessage = await _httpClient.GetAsync("discount");
            var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultCouponDto>>();
            return values;
        }

        public async Task UpdateCouponAsync(UpdateCouponDto updateCouponDto)
        {
            await _httpClient.PutAsJsonAsync("discount", updateCouponDto);
        }
    }
}
