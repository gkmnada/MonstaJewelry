﻿using DtoLayer.CatalogDto.ProductDto;

namespace DtoLayer.CatalogDto.ProductDetailDto
{
    public class GetProductDetailDto
    {
        public string ProductDetailID { get; set; }
        public string ProductDescription { get; set; }
        public string ProductID { get; set; }
        public ResultProductDto Product { get; set; }
    }
}
