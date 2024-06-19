using BusinessLayer.Order.OrderAddressServices;
using BusinessLayer.Order.OrderDetailServices;
using BusinessLayer.Order.OrderServices;
using DtoLayer.OrderDto.OrderDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PresentationUI.Areas.Administrator.Models;
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
        private readonly IOrderAddressService _orderAddressService;

        public OrderController(IOrderService orderService, IUserService userService, IOrderDetailService orderDetailService, IOrderAddressService orderAddressService)
        {
            _orderService = orderService;
            _userService = userService;
            _orderDetailService = orderDetailService;
            _orderAddressService = orderAddressService;
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
            var order = await _orderService.GetOrderAsync(id);
            var details = await _orderDetailService.ListOrderDetailAsync(id);
            var address = await _orderAddressService.GetOrderAddressAsync(id);
            var user = await _userService.ListUser();
            var userDetail = await _userService.GetUserById(order.UserID);

            var result = new GetOrderDto
            {
                OrderID = order.OrderID,
                UserID = order.UserID,
                TotalPrice = order.TotalPrice,
                OrderDate = order.OrderDate,
                Status = order.Status
            };

            var orderViewModel = new OrderViewModel
            {
                GetOrderDto = result,
                ResultOrderDetailDto = details,
                GetOrderAddressDto = address,
                UserViewModel = userDetail
            };

            var totalPrice = order.TotalPrice;

            decimal kdvRate = 1.18m;

            var subTotal = Math.Round(totalPrice / kdvRate);

            var kdvTotal = Math.Round(totalPrice - subTotal);

            ViewBag.SubTotal = decimal.Parse(subTotal.ToString("F2"));
            ViewBag.TotalPrice = totalPrice;
            ViewBag.KDV = decimal.Parse(kdvTotal.ToString("F2")); ;

            return View(orderViewModel);
        }
    }
}
