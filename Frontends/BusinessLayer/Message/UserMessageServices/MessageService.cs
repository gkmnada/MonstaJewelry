using DtoLayer.MessageDto.UserMessageDto;
using System.Net.Http.Json;

namespace BusinessLayer.Message.UserMessageServices
{
    public class MessageService : IMessageService
    {
        private readonly HttpClient _httpClient;

        public MessageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateMessageAsync(CreateMessageDto createMessageDto)
        {
            await _httpClient.PostAsJsonAsync("message", createMessageDto);
        }

        public async Task DeleteMessageAsync(int id)
        {
            await _httpClient.DeleteAsync("message?id=" + id);
        }

        public async Task<GetMessageDto> GetMessageAsync(int id)
        {
            var response = await _httpClient.GetAsync("message/getmessage?id=" + id);
            var value = await response.Content.ReadFromJsonAsync<GetMessageDto>();
            return value;
        }

        public async Task<List<ResultMessageDto>> ListMessageAsync()
        {
            var response = await _httpClient.GetAsync("message");
            var value = await response.Content.ReadFromJsonAsync<List<ResultMessageDto>>();
            return value;
        }

        public async Task UpdateMessageAsync(UpdateMessageDto updateMessageDto)
        {
            await _httpClient.PutAsJsonAsync("message", updateMessageDto);
        }
    }
}
