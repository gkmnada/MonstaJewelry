using AutoMapper;
using CatalogAPI.Dtos.SliderDto;
using CatalogAPI.Entities;
using CatalogAPI.Settings;
using MongoDB.Driver;

namespace CatalogAPI.Services.SliderServices
{
    public class SliderService : ISliderService
    {
        private readonly IMongoCollection<Slider> _sliderCollection;
        private readonly IMapper _mapper;

        public SliderService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _sliderCollection = database.GetCollection<Slider>(databaseSettings.SliderCollectionName);
            _mapper = mapper;
        }

        public async Task CreateSliderAsync(CreateSliderDto createSliderDto)
        {
            var value = _mapper.Map<Slider>(createSliderDto);
            await _sliderCollection.InsertOneAsync(value);
        }

        public async Task DeleteSliderAsync(string id)
        {
            await _sliderCollection.DeleteOneAsync(x => x.SliderID == id);
        }

        public async Task<GetSliderDto> GetSliderAsync(string id)
        {
            var values = await _sliderCollection.Find(x => x.SliderID == id).FirstOrDefaultAsync();
            return _mapper.Map<GetSliderDto>(values);
        }

        public async Task<List<ResultSliderDto>> ListSliderAsync()
        {
            var values = await _sliderCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultSliderDto>>(values);
        }

        public async Task UpdateSliderAsync(UpdateSliderDto updateSliderDto)
        {
            var value = _mapper.Map<Slider>(updateSliderDto);
            await _sliderCollection.FindOneAndReplaceAsync(x => x.SliderID == updateSliderDto.SliderID, value);
        }
    }
}
