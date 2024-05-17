using BusinessLayer.Order.AddressServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PresentationUI.Services.Abstract;

namespace PresentationUI.ViewComponents.Order
{
    public class Address : ViewComponent
    {
        private readonly IUserService _userService;
        private readonly IAddressService _addressService;

        public Address(IUserService userService, IAddressService addressService)
        {
            _userService = userService;
            _addressService = addressService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var user = await _userService.GetUserInfo();
            id = user.Id;

            var values = await _addressService.ListAddressByUserAsync(id);

            List<SelectListItem> addressList = (from x in values
                                                select new SelectListItem
                                                {
                                                    Value = x.AddressID,
                                                    Text = x.AddressTitle
                                                }).ToList();

            ViewBag.AddressList = addressList;

            return View(values);
        }
    }
}
