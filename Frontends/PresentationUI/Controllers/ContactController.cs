using BusinessLayer.Message.UserMessageServices;
using DtoLayer.MessageDto.UserMessageDto;
using Microsoft.AspNetCore.Mvc;

namespace PresentationUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IMessageService _messageService;

        public ContactController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateMessageDto createMessageDto)
        {
            await _messageService.CreateMessageAsync(createMessageDto);
            return RedirectToAction("Index", "Home");
        }
    }
}
