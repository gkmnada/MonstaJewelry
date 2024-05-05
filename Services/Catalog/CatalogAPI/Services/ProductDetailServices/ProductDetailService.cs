using AutoMapper;
using CatalogAPI.Dtos.ProductDetailDto;
using CatalogAPI.Entities;
using CatalogAPI.Settings;
using MongoDB.Driver;

namespace CatalogAPI.Services.ProductDetailServices
{
    public class ProductDetailService : IProductDetailService
    {
        private readonly IMongoCollection<ProductDetail> _productDetailCollection;
        private readonly IMapper _mapper;
        private readonly IMongoCollection<Product> _productCollection;

        public ProductDetailService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _productDetailCollection = database.GetCollection<ProductDetail>(_databaseSettings.ProductDetailCollectionName);
            _productCollection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
            _mapper = mapper;
        }

        public async Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto)
        {
            var value = _mapper.Map<ProductDetail>(createProductDetailDto);
            await _productDetailCollection.InsertOneAsync(value);
        }

        public async Task DeleteProductDetailAsync(string id)
        {
            await _productDetailCollection.DeleteOneAsync(x => x.ProductDetailID == id);
        }

        public async Task<GetProductDetailDto> GetProductDetailAsync(string id)
        {
            var values = await _productDetailCollection.Find(x => x.ProductDetailID == id).FirstOrDefaultAsync();
            return _mapper.Map<GetProductDetailDto>(values);
        }

        public async Task<GetProductDetailDto> GetProductDetailWithProductAsync(string id)
        {
            var values = await _productDetailCollection.Find(x => x.ProductID == id).FirstOrDefaultAsync();
            values.Product = await _productCollection.Find(x => x.ProductID == values.ProductID).FirstAsync();
            return _mapper.Map<GetProductDetailDto>(values);
        }

        public async Task<List<ResultProductDetailDto>> ListProductDetailAsync()
        {
            var values = await _productDetailCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductDetailDto>>(values);
        }

        public async Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto)
        {
            var value = _mapper.Map<ProductDetail>(updateProductDetailDto);
            await _productDetailCollection.FindOneAndReplaceAsync(x => x.ProductDetailID == updateProductDetailDto.ProductDetailID, value);
        }
    }
}
