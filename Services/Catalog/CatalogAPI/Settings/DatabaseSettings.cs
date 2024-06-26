﻿using System.Reflection.Metadata.Ecma335;

namespace CatalogAPI.Settings
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string CategoryCollectionName { get; set; }
        public string ProductCollectionName { get; set; }
        public string ProductDetailCollectionName { get; set; }
        public string ProductImageCollectionName { get; set; }
        public string SliderCollectionName { get; set; }
        public string BannerCollectionName { get; set; }
        public string ExclusiveSelectionsCollectionName { get; set; }
        public string FooterCollectionName { get; set; }
        public string SubscribeCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
