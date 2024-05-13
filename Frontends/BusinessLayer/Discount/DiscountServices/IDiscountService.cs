using DtoLayer.DiscountDto.CouponDto;

namespace BusinessLayer.Discount.DiscountServices
{
    public interface IDiscountService
    {
        Task<GetCouponDto> GetCouponCodeAsync(string code);
    }
}
