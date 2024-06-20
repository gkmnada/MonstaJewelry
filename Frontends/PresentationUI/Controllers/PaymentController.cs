using BusinessLayer.Basket;
using BusinessLayer.Discount.DiscountServices;
using BusinessLayer.Order.AddressServices;
using BusinessLayer.Order.OrderServices;
using DtoLayer.OrderDto.OrderDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PresentationUI.Services.Abstract;

namespace PresentationUI.Controllers
{
    [Authorize]
    public class PaymentController : Controller
    {
        private readonly IBasketService _basketService;
        private readonly IDiscountService _discountService;
        private readonly IUserService _userService;
        private readonly IOrderService _orderService;
        private readonly IAddressService _addressService;

        public PaymentController(IBasketService basketService, IDiscountService discountService, IOrderService orderService, IUserService userService, IAddressService addressService)
        {
            _basketService = basketService;
            _discountService = discountService;
            _orderService = orderService;
            _userService = userService;
            _addressService = addressService;
        }

        [HttpGet]
        public IActionResult Index(string code, string address)
        {
            ViewBag.Code = code;
            ViewBag.Address = address;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string code, string address, CreateOrderWithDetailDto createOrderWithDetailDto)
        {
            var user = await _userService.GetUserInfo();
            var userId = user.Id;

            if (code == null)
            {
                var basket = await _basketService.GetBasketAsync();
                var basketItem = basket.BasketItem;

                var totalPrice = Math.Round(basket.TotalPrice);
                totalPrice = decimal.Parse(totalPrice.ToString("F2"));

                var taxPrice = Math.Round(totalPrice / 100 * 18);
                taxPrice = decimal.Parse(taxPrice.ToString("F2"));

                var total = Math.Round(totalPrice + taxPrice);
                total = decimal.Parse(total.ToString("F2"));

                createOrderWithDetailDto = new CreateOrderWithDetailDto
                {
                    UserID = userId,
                    TotalPrice = total,
                    OrderDate = DateTime.Now,
                    OrderDetails = new List<OrderDetailDto>(),
                    OrderAddresses = new List<OrderAddressDto>()
                };

                foreach (var item in basketItem)
                {
                    var price = Math.Round(item.Price);
                    price = decimal.Parse(price.ToString("F2"));

                    createOrderWithDetailDto.OrderDetails.Add(new OrderDetailDto
                    {
                        ProductID = item.ProductID,
                        ProductName = item.ProductName,
                        ProductPrice = price,
                        ProductImage = item.ProductImage,
                        Quantity = item.Quantity,
                        TotalPrice = price * item.Quantity
                    });
                }

                var values = await _addressService.GetAddressAsync(address);

                createOrderWithDetailDto.OrderAddresses.Add(new OrderAddressDto
                {
                    AddressID = values.AddressID,
                    UserID = userId,
                    Name = values.Name,
                    Surname = values.Surname,
                    Email = values.Email,
                    Phone = values.Phone,
                    Country = values.Country,
                    City = values.City,
                    District = values.District,
                    AddressDetail1 = values.AddressDetail1,
                    AddressDetail2 = values.AddressDetail2,
                    AddressTitle = values.AddressTitle
                });

                await _orderService.CreateOrderWithDetailAsync(createOrderWithDetailDto);
                await _basketService.DeleteBasketAsync();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                var basket = await _basketService.GetBasketAsync();
                var basketItem = basket.BasketItem;

                var coupon = await _discountService.GetCouponCodeAsync(code);
                int couponRate = coupon.Rate;

                var totalPrice = basket.TotalPrice;
                var discountRate = coupon.Rate;

                var discountPrice = Math.Round(totalPrice - (totalPrice * couponRate / 100));
                discountPrice = decimal.Parse(discountPrice.ToString("F2"));

                var taxPrice = Math.Round(discountPrice / 100 * 18);
                taxPrice = decimal.Parse(taxPrice.ToString("F2"));

                var totalDiscount = Math.Round(discountPrice + taxPrice);
                totalDiscount = decimal.Parse(totalDiscount.ToString("F2"));

                createOrderWithDetailDto = new CreateOrderWithDetailDto
                {
                    UserID = userId,
                    TotalPrice = totalDiscount,
                    OrderDate = DateTime.Now,
                    OrderDetails = new List<OrderDetailDto>(),
                    OrderAddresses = new List<OrderAddressDto>()
                };

                foreach (var item in basketItem)
                {
                    var productPrice = Math.Round(item.Price - (item.Price / 100 * couponRate));
                    productPrice = decimal.Parse(productPrice.ToString("F2"));

                    createOrderWithDetailDto.OrderDetails.Add(new OrderDetailDto
                    {
                        ProductID = item.ProductID,
                        ProductName = item.ProductName,
                        ProductPrice = productPrice,
                        Quantity = item.Quantity,
                        TotalPrice = productPrice * item.Quantity
                    });
                }

                var values = await _addressService.GetAddressAsync(address);

                createOrderWithDetailDto.OrderAddresses.Add(new OrderAddressDto
                {
                    AddressID = values.AddressID,
                    UserID = userId,
                    Name = values.Name,
                    Surname = values.Surname,
                    Email = values.Email,
                    Phone = values.Phone,
                    Country = values.Country,
                    City = values.City,
                    District = values.District,
                    AddressDetail1 = values.AddressDetail1,
                    AddressDetail2 = values.AddressDetail2,
                    AddressTitle = values.AddressTitle
                });

                await _orderService.CreateOrderWithDetailAsync(createOrderWithDetailDto);
                await _basketService.DeleteBasketAsync();
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
