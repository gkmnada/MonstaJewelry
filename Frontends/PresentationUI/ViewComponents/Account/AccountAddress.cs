using BusinessLayer.Order.AddressServices;
using Microsoft.AspNetCore.Mvc;
using PresentationUI.Services.Abstract;

namespace PresentationUI.ViewComponents.Account
{
    public class AccountAddress : ViewComponent
    {
        private readonly IAddressService _addressService;
        private readonly IUserService _userService;

        public AccountAddress(IAddressService addressService, IUserService userService)
        {
            _addressService = addressService;
            _userService = userService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userService.GetUserInfo();
            string id = user.Id;
            var values = await _addressService.ListAddressByUserAsync(id);
            return View(values);
        }
    }
}
