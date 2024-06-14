using BusinessLayer.Order.OrderServices;
using DtoLayer.OrderDto.OrderDto;
using Microsoft.AspNetCore.Mvc;
using PresentationUI.Services.Abstract;

namespace PresentationUI.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IUserService _userService;

        public OrderController(IOrderService orderService, IUserService userService)
        {
            _orderService = orderService;
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _orderService.ListOrderAsync();
            var user = await _userService.ListUser();

            var userDictionary = user.ToDictionary(x => x.Id, x => x.Name + ' ' + x.Surname);

            var result = values.Select(x => new ResultOrderDto
            {
                OrderID = x.OrderID,
                UserID = x.UserID,
                Name = userDictionary.ContainsKey(x.UserID) ? userDictionary[x.UserID] : "Unknown",
                TotalPrice = x.TotalPrice,
                OrderDate = x.OrderDate,
                Status = x.Status,
            }).ToList();

            return View(result);
        }
    }
}
