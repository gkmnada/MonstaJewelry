using AutoMapper;
using CatalogAPI.Dtos.FooterDto;
using CatalogAPI.Entities;
using CatalogAPI.Settings;
using MongoDB.Driver;

namespace CatalogAPI.Services.FooterServices
{
    public class FooterService : IFooterService
    {
        private readonly IMongoCollection<Footer> _footerCollection;
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;

        public FooterService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            _mapper = mapper;
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _footerCollection = database.GetCollection<Footer>(databaseSettings.FooterCollectionName);
            _categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
        }

        public async Task CreateFooterAsync(CreateFooterDto createFooterDto)
        {
            var value = _mapper.Map<Footer>(createFooterDto);
            await _footerCollection.InsertOneAsync(value);
        }

        public async Task DeleteFooterAsync(string id)
        {
            await _footerCollection.DeleteOneAsync(x => x.FooterID == id);
        }

        public async Task<GetFooterDto> GetFooterAsync(string id)
        {
            var values = await _footerCollection.Find(x => x.FooterID == id).FirstOrDefaultAsync();
            return _mapper.Map<GetFooterDto>(values);
        }

        public async Task<List<ResultFooterDto>> ListFooterAsync()
        {
            var values = await _footerCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultFooterDto>>(values);
        }

        public async Task<List<ResultFooterWithCategoryDto>> ListFooterWithCategoryAsync()
        {
            var values = await _footerCollection.Find(x => true).ToListAsync();
            foreach (var item in values)
            {
                item.Category = await _categoryCollection.Find(x => x.CategoryID == item.CategoryID).FirstAsync();
            }
            return _mapper.Map<List<ResultFooterWithCategoryDto>>(values);
        }

        public async Task UpdateFooterAsync(UpdateFooterDto updateFooterDto)
        {
            var value = _mapper.Map<Footer>(updateFooterDto);
            await _footerCollection.FindOneAndReplaceAsync(x => x.FooterID == updateFooterDto.FooterID, value);
        }
    }
}
