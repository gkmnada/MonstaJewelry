using AutoMapper;
using CatalogAPI.Dtos.ProductImageDto;
using CatalogAPI.Entities;
using CatalogAPI.Settings;
using MongoDB.Driver;

namespace CatalogAPI.Services.ProductImageServices
{
    public class ProductImageService : IProductImageService
    {
        private readonly IMongoCollection<ProductImage> _productImageCollection;
        private readonly IMapper _mapper;

        public ProductImageService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _productImageCollection = database.GetCollection<ProductImage>(_databaseSettings.ProductImageCollectionName);
            _mapper = mapper;
        }

        public async Task CreateProductImageAsync(CreateProductImageDto createProductImageDto)
        {
            var value = _mapper.Map<ProductImage>(createProductImageDto);
            await _productImageCollection.InsertOneAsync(value);
        }

        public async Task DeleteProductImageAsync(string id)
        {
            await _productImageCollection.DeleteOneAsync(x => x.ProductImageID == id);
        }

        public async Task<GetProductImageDto> GetProductImageAsync(string id)
        {
            var values = await _productImageCollection.Find(x => x.ProductImageID == id).FirstOrDefaultAsync();
            return _mapper.Map<GetProductImageDto>(values);
        }

        public async Task<GetProductImageDto> GetProductImageWithProductAsync(string id)
        {
            var values = await _productImageCollection.Find(x => x.ProductID == id).FirstOrDefaultAsync();
            return _mapper.Map<GetProductImageDto>(values);
        }

        public async Task<List<ResultProductImageDto>> ListProductImageAsync()
        {
            var values = await _productImageCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductImageDto>>(values);
        }

        public async Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto)
        {
            var value = _mapper.Map<ProductImage>(updateProductImageDto);
            await _productImageCollection.FindOneAndReplaceAsync(x => x.ProductImageID == updateProductImageDto.ProductImageID, value);
        }
    }
}
