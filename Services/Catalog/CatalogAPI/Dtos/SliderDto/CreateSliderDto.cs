namespace CatalogAPI.Dtos.SliderDto
{
    public class CreateSliderDto
    {
        public string ProductDescription { get; set; }
        public string ProductImage { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public string PriceDescription { get; set; }
    }
}
