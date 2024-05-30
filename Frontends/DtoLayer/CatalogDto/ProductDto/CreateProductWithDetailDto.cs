namespace DtoLayer.CatalogDto.ProductDto
{
    public class CreateProductWithDetailDto
    {
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductImage { get; set; }
        public string ProductDescription { get; set; }
        public string CategoryID { get; set; }
        public string DetailDescription { get; set; }
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string Image3 { get; set; }
    }
}
