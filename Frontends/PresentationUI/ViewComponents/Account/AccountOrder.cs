using BusinessLayer.Order.OrderServices;
using Microsoft.AspNetCore.Mvc;
using PresentationUI.Services.Abstract;

namespace PresentationUI.ViewComponents.Account
{
    public class AccountOrder : ViewComponent
    {
        private readonly IOrderService _orderService;
        private readonly IUserService _userService;

        public AccountOrder(IOrderService orderService, IUserService userService)
        {
            _orderService = orderService;
            _userService = userService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userService.GetUserInfo();
            string id = user.Id;
            var orders = await _orderService.ListOrderByUserAsync(id);
            return View(orders);
        }
    }
}
