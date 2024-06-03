using AutoMapper;
using CatalogAPI.Dtos.ExclusiveSelectionsDto;
using CatalogAPI.Entities;
using CatalogAPI.Settings;
using MongoDB.Driver;

namespace CatalogAPI.Services.ExclusiveSelectionsServices
{
    public class ExclusiveSelectionsService : IExclusiveSelectionsService
    {
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMongoCollection<ExclusiveSelections> _exclusiveSelectionsCollection;
        private readonly IMapper _mapper;

        public ExclusiveSelectionsService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _exclusiveSelectionsCollection = database.GetCollection<ExclusiveSelections>(_databaseSettings.ExclusiveSelectionsCollectionName);
            _categoryCollection = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);
            _mapper = mapper;
        }

        public async Task CreateExclusiveSelectionsAsync(CreateExclusiveSelectionsDto createExclusiveSelectionsDto)
        {
            var value = _mapper.Map<ExclusiveSelections>(createExclusiveSelectionsDto);
            await _exclusiveSelectionsCollection.InsertOneAsync(value);
        }

        public async Task DeleteExclusiveSelectionsAsync(string id)
        {
            await _exclusiveSelectionsCollection.DeleteOneAsync(x => x.ExclusiveSelectionsID == id);
        }

        public async Task<GetExclusiveSelectionsDto> GetExclusiveSelectionsAsync(string id)
        {
            var values = await _exclusiveSelectionsCollection.Find(x => x.ExclusiveSelectionsID == id).FirstOrDefaultAsync();
            return _mapper.Map<GetExclusiveSelectionsDto>(values);
        }

        public async Task<List<ResultExclusiveSelectionsDto>> ListExclusiveSelectionsAsync()
        {
            var values = await _exclusiveSelectionsCollection.Find(x => true).ToListAsync();
            foreach (var item in values)
            {
                item.Category = await _categoryCollection.Find(x => x.CategoryID == item.CategoryID).FirstAsync();
            }
            return _mapper.Map<List<ResultExclusiveSelectionsDto>>(values);
        }

        public async Task UpdateExclusiveSelectionsAsync(UpdateExclusiveSelectionsDto updateExclusiveSelectionsDto)
        {
            var value = _mapper.Map<ExclusiveSelections>(updateExclusiveSelectionsDto);
            await _exclusiveSelectionsCollection.FindOneAndReplaceAsync(x => x.ExclusiveSelectionsID == updateExclusiveSelectionsDto.ExclusiveSelectionsID, value);
        }
    }
}
