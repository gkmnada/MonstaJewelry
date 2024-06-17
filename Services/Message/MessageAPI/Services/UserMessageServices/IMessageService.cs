using MessageAPI.Dtos.UserMessageDto;

namespace MessageAPI.Services.UserMessageServices
{
    public interface IMessageService
    {
        Task<List<ResultMessageDto>> ListMessageAsync();
        Task CreateMessageAsync(CreateMessageDto createMessageDto);
        Task UpdateMessageAsync(UpdateMessageDto updateMessageDto);
        Task DeleteMessageAsync(int id);
        Task<GetMessageDto> GetMessageAsync(int id);
    }
}
