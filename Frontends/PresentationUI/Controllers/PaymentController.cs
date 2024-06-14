using BusinessLayer.Basket;
using BusinessLayer.Discount.DiscountServices;
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

        public PaymentController(IBasketService basketService, IDiscountService discountService, IOrderService orderService, IUserService userService)
        {
            _basketService = basketService;
            _discountService = discountService;
            _orderService = orderService;
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Index(string code)
        {
            ViewBag.Code = code;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string code, CreateOrderWithDetailDto createOrderWithDetailDto)
        {
            var user = await _userService.GetUserInfo();
            var userId = user.Id;

            if (code == null)
            {
                var basket = await _basketService.GetBasketAsync();
                var basketItem = basket.BasketItem;

                var taxPrice = Math.Round(basket.TotalPrice / 100 * 18, 2);
                var totalPrice = Math.Round(basket.TotalPrice + taxPrice, 2);

                createOrderWithDetailDto = new CreateOrderWithDetailDto
                {
                    UserID = userId,
                    TotalPrice = totalPrice,
                    OrderDate = DateTime.Now,
                    OrderDetails = new List<OrderDetailDto>()
                };

                foreach (var item in basketItem)
                {
                    createOrderWithDetailDto.OrderDetails.Add(new OrderDetailDto
                    {
                        ProductID = item.ProductID,
                        ProductName = item.ProductName,
                        ProductPrice = item.Price,
                        Quantity = item.Quantity,
                        TotalPrice = item.Price * item.Quantity
                    });
                }
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

                var discountPrice = Math.Round(totalPrice - totalPrice / 100 * couponRate, 2);
                var taxPrice = Math.Round(discountPrice / 100 * 18, 2);
                var totalDiscount = Math.Round(discountPrice + taxPrice, 2);

                createOrderWithDetailDto = new CreateOrderWithDetailDto
                {
                    UserID = userId,
                    TotalPrice = totalDiscount,
                    OrderDate = DateTime.Now,
                    OrderDetails = new List<OrderDetailDto>()
                };

                foreach (var item in basketItem)
                {
                    createOrderWithDetailDto.OrderDetails.Add(new OrderDetailDto
                    {
                        ProductID = item.ProductID,
                        ProductName = item.ProductName,
                        ProductPrice = item.Price - item.Price / 100 * couponRate,
                        Quantity = item.Quantity,
                        TotalPrice = item.Price - item.Price / 100 * couponRate * item.Quantity
                    });
                }
                await _orderService.CreateOrderWithDetailAsync(createOrderWithDetailDto);
                await _basketService.DeleteBasketAsync();
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
