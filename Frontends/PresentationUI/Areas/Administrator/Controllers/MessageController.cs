using BusinessLayer.Message.UserMessageServices;
using Microsoft.AspNetCore.Mvc;

namespace PresentationUI.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class MessageController : Controller
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public async Task<IActionResult> Index()
        {
            var messages = await _messageService.ListMessageAsync();
            return View(messages);
        }

        public async Task<IActionResult> DeleteMessage(int id)
        {

            await _messageService.DeleteMessageAsync(id);
            return RedirectToAction("Index", "Message", new { area = "Administrator" });
        }
    }
}
