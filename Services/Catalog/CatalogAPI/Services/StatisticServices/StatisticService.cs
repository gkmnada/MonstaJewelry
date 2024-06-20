using CatalogAPI.Dtos.StatisticDto;
using CatalogAPI.Entities;
using CatalogAPI.Settings;
using MongoDB.Driver;

namespace CatalogAPI.Services.StatisticServices
{
    public class StatisticService : IStatisticService
    {
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMongoCollection<Category> _categoryCollection;

        public StatisticService(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _productCollection = database.GetCollection<Product>(databaseSettings.ProductCollectionName);
            _categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
        }

        public async Task<long> GetCategoryCountAsync()
        {
            return await _categoryCollection.CountDocumentsAsync(FilterDefinition<Category>.Empty);
        }

        public async Task<long> GetProductCountAsync()
        {
            return await _productCollection.CountDocumentsAsync(FilterDefinition<Product>.Empty);
        }

        public async Task<List<GetProductCountByCategoryDto>> GetProductCountByCategoryAsync()
        {
            var categories = await _categoryCollection.Find(FilterDefinition<Category>.Empty).ToListAsync();
            var productCountByCategoryList = new List<GetProductCountByCategoryDto>();

            foreach (var category in categories)
            {
                var productCount = await _productCollection.CountDocumentsAsync(p => p.CategoryID == category.CategoryID);
                var productCountByCategory = new GetProductCountByCategoryDto
                {
                    CategoryName = category.CategoryName,
                    ProductCount = productCount
                };

                productCountByCategoryList.Add(productCountByCategory);
            }
            return productCountByCategoryList;
        }
    }
}
