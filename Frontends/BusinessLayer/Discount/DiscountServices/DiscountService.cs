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

        public async Task<GetCouponDto> GetCouponCodeAsync(string code)
        {
            var responseMessage = await _httpClient.GetAsync("discount/getcouponcode?code=" + code);
            var values = await responseMessage.Content.ReadFromJsonAsync<GetCouponDto>();
            return values;
        }
    }
}
