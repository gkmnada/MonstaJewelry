using DtoLayer.OrderDto.OrderAddressDto;
using DtoLayer.OrderDto.OrderDetailDto;
using DtoLayer.OrderDto.OrderDto;
using PresentationUI.Models;

namespace PresentationUI.Areas.Administrator.Models
{
    public class OrderViewModel
    {
        public GetOrderDto GetOrderDto { get; set; }
        public List<ResultOrderDetailDto> ResultOrderDetailDto { get; set; }
        public GetOrderAddressDto GetOrderAddressDto { get; set; }
        public UserViewModel UserViewModel { get; set; }
    }
}
