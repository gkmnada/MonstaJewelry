using CatalogAPI.Dtos.SubscribeDto;

namespace CatalogAPI.Services.SubscribeServices
{
    public interface ISubscribeService
    {
        Task<List<ResultSubscribeDto>> ListSubscribeAsync();
        Task CreateSubscribeAsync(CreateSubscribeDto createSubscribeDto);
        Task UpdateSubscribeAsync(UpdateSubscribeDto updateSubscribeDto);
        Task DeleteSubscribeAsync(string id);
        Task<GetSubscribeDto> GetSubscribeAsync(string id);
    }
}
