namespace DtoLayer.CatalogDto.SliderDto
{
    public class GetSliderDto
    {
        public string SliderID { get; set; }
        public string ProductID { get; set; }
        public string ProductDescription { get; set; }
        public string ProductImage { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public string PriceDescription { get; set; }
        public string CouponCode { get; set; }
    }
}
