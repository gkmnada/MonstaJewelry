namespace DtoLayer.DiscountDto.CouponDto
{
    public class CreateCouponDto
    {
        public string Code { get; set; }
        public int Rate { get; set; }
        public bool IsActive { get; set; }
        public DateTime ValidityDate { get; set; }
    }
}
