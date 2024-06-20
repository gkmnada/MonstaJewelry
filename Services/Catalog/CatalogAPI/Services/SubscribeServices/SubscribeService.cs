using AutoMapper;
using CatalogAPI.Dtos.SubscribeDto;
using CatalogAPI.Entities;
using CatalogAPI.Settings;
using MongoDB.Driver;

namespace CatalogAPI.Services.SubscribeServices
{
    public class SubscribeService : ISubscribeService
    {
        private readonly IMongoCollection<Subscribe> _subscribeCollection;
        private readonly IMapper _mapper;

        public SubscribeService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _subscribeCollection = database.GetCollection<Subscribe>(databaseSettings.SubscribeCollectionName);
            _mapper = mapper;
        }

        public async Task CreateSubscribeAsync(CreateSubscribeDto createSubscribeDto)
        {
            var value = _mapper.Map<Subscribe>(createSubscribeDto);
            await _subscribeCollection.InsertOneAsync(value);
        }

        public async Task DeleteSubscribeAsync(string id)
        {
            await _subscribeCollection.DeleteOneAsync(x => x.SubscribeID == id);
        }

        public async Task<GetSubscribeDto> GetSubscribeAsync(string id)
        {
            var values = await _subscribeCollection.Find(x => x.SubscribeID == id).FirstOrDefaultAsync();
            return _mapper.Map<GetSubscribeDto>(values);
        }

        public async Task<List<ResultSubscribeDto>> ListSubscribeAsync()
        {
            var values = await _subscribeCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultSubscribeDto>>(values);
        }

        public async Task UpdateSubscribeAsync(UpdateSubscribeDto updateSubscribeDto)
        {
            var value = _mapper.Map<Subscribe>(updateSubscribeDto);
            await _subscribeCollection.FindOneAndReplaceAsync(x => x.SubscribeID == updateSubscribeDto.SubscribeID, value);
        }
    }
}
