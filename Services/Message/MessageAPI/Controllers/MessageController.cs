using MessageAPI.Dtos.UserMessageDto;
using MessageAPI.Services.UserMessageServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MessageAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet]
        public async Task<IActionResult> ListMessage()
        {
            var messages = await _messageService.ListMessageAsync();
            return Ok(messages);
        }

        [HttpGet("GetMessage")]
        public async Task<IActionResult> GetMessage(int id)
        {
            var message = await _messageService.GetMessageAsync(id);
            return Ok(message);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMessage(CreateMessageDto createMessageDto)
        {
            await _messageService.CreateMessageAsync(createMessageDto);
            return Ok("Başarılı");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMessage(UpdateMessageDto updateMessageDto)
        {
            await _messageService.UpdateMessageAsync(updateMessageDto);
            return Ok("Başarılı");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMessage(int id)
        {
            await _messageService.DeleteMessageAsync(id);
            return Ok("Başarılı");
        }
    }
}
