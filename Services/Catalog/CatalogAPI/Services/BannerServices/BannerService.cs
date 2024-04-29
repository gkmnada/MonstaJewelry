using AutoMapper;
using CatalogAPI.Dtos.BannerDto;
using CatalogAPI.Entities;
using CatalogAPI.Settings;
using MongoDB.Driver;

namespace CatalogAPI.Services.BannerServices
{
    public class BannerService : IBannerService
    {
        private readonly IMongoCollection<Banner> _bannerCollection;
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;

        public BannerService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _bannerCollection = database.GetCollection<Banner>(databaseSettings.BannerCollectionName);
            _categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
            _mapper = mapper;
        }

        public async Task CreateBannerAsync(CreateBannerDto createBannerDto)
        {
            var value = _mapper.Map<Banner>(createBannerDto);
            await _bannerCollection.InsertOneAsync(value);
        }

        public async Task DeleteBannerAsync(string id)
        {
            await _bannerCollection.DeleteOneAsync(x => x.BannerID == id);
        }

        public async Task<GetBannerDto> GetBannerAsync(string id)
        {
            var values = await _bannerCollection.Find(x => x.BannerID == id).FirstOrDefaultAsync();
            return _mapper.Map<GetBannerDto>(values);
        }

        public async Task<List<ResultBannerDto>> ListBannerAsync()
        {
            var values = await _bannerCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultBannerDto>>(values);
        }

        public async Task<List<ResultBannerWithCategoryDto>> ListBannerWithCategoryAsync()
        {
            var values = await _bannerCollection.Find(x => true).ToListAsync();
            foreach (var item in values)
            {
                item.Category = await _categoryCollection.Find(x => x.CategoryID == item.CategoryID).FirstAsync();
            }
            return _mapper.Map<List<ResultBannerWithCategoryDto>>(values);
        }

        public async Task UpdateBannerAsync(UpdateBannerDto updateBannerDto)
        {
            var value = _mapper.Map<Banner>(updateBannerDto);
            await _bannerCollection.FindOneAndReplaceAsync(x => x.BannerID == updateBannerDto.BannerID, value);
        }
    }
}
