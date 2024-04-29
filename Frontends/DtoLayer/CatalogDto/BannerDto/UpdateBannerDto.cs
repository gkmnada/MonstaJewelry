﻿namespace DtoLayer.CatalogDto.BannerDto
{
    public class UpdateBannerDto
    {
        public string BannerID { get; set; }
        public string ProductImage { get; set; }
        public string CategoryID { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
    }
}