using Application.Features.Mediator.Commands.OrderCommands;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.Mediator.Handlers.OrderHandlers
{
    public class CreateOrderWithDetailCommandHandler : IRequestHandler<CreateOrderWithDetailCommand>
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<OrderDetail> _orderDetailRepository;

        public CreateOrderWithDetailCommandHandler(IRepository<Order> orderRepository, IRepository<OrderDetail> orderDetailRepository)
        {
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
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
                    Quantity = detail.Quantity,
                    TotalPrice = detail.TotalPrice,
                    OrderID = order.OrderID
                });
            }

            foreach (var orderDetail in orderDetails)
            {
                await _orderDetailRepository.CreateAsync(orderDetail);
            }

            return Unit.Value;
        }
    }
}
