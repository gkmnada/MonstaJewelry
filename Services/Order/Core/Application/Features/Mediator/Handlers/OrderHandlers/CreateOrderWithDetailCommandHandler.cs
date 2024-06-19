using Application.Features.Mediator.Commands.OrderCommands;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.Mediator.Handlers.OrderHandlers
{
    public class CreateOrderWithDetailCommandHandler : IRequestHandler<CreateOrderWithDetailCommand>
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<OrderAddress> _orderAddressRepository;
        private readonly IRepository<OrderDetail> _orderDetailRepository;

        public CreateOrderWithDetailCommandHandler(IRepository<Order> orderRepository, IRepository<OrderDetail> orderDetailRepository, IRepository<OrderAddress> orderAddressRepository)
        {
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
            _orderAddressRepository = orderAddressRepository;
        }

        public async Task<Unit> Handle(CreateOrderWithDetailCommand request, CancellationToken cancellationToken)
        {
            var order = new Order
            {
                UserID = request.UserID,
                TotalPrice = request.TotalPrice,
                OrderDate = request.OrderDate,
                Status = false
            };

            await _orderRepository.CreateAsync(order);

            var orderDetails = new List<OrderDetail>();

            foreach (var detail in request.OrderDetails)
            {
                orderDetails.Add(new OrderDetail
                {
                    ProductID = detail.ProductID,
                    ProductName = detail.ProductName,
                    ProductPrice = detail.ProductPrice,
                    ProductImage = detail.ProductImage,
                    Quantity = detail.Quantity,
                    TotalPrice = detail.TotalPrice,
                    OrderID = order.OrderID
                });
            }

            foreach (var orderDetail in orderDetails)
            {
                await _orderDetailRepository.CreateAsync(orderDetail);
            }

            var orderAddresses = new List<OrderAddress>();

            foreach (var address in request.OrderAddresses)
            {
                orderAddresses.Add(new OrderAddress
                {
                    AddressID = address.AddressID,
                    UserID = address.UserID,
                    Name = address.Name,
                    Surname = address.Surname,
                    Email = address.Email,
                    Phone = address.Phone,
                    Country = address.Country,
                    City = address.City,
                    District = address.District,
                    AddressDetail1 = address.AddressDetail1,
                    AddressDetail2 = address.AddressDetail2,
                    AddressTitle = address.AddressTitle,
                    OrderID = order.OrderID
                });
            }

            foreach (var orderAddress in orderAddresses)
            {
                await _orderAddressRepository.CreateAsync(orderAddress);
            }

            return Unit.Value;
        }
    }
}
