using BusinessLayer.Order.OrderDetailServices;
using BusinessLayer.Order.OrderServices;
using DtoLayer.OrderDto.OrderDetailDto;
using DtoLayer.OrderDto.OrderDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PresentationUI.Services.Abstract;

namespace PresentationUI.Areas.Administrator.Controllers
{
    [Authorize]
    [Area("Administrator")]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IUserService _userService;
        private readonly IOrderDetailService _orderDetailService;

        public OrderController(IOrderService orderService, IUserService userService, IOrderDetailService orderDetailService)
        {
            _orderService = orderService;
            _userService = userService;
            _orderDetailService = orderDetailService;
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

        public async Task<IActionResult> OrderDetail(string id)
        {
            var values = await _orderDetailService.GetOrderDetailAsync(id);
            return View(values);
        }
    }
}
