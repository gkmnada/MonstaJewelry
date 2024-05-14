using Application.Features.CQRS.Commands.OrderDetailCommands;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class CreateOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public CreateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateOrderDetailCommand createOrderDetailCommand)
        {
            await _repository.CreateAsync(new OrderDetail
            {
                ProductID = createOrderDetailCommand.ProductID,
                ProductName = createOrderDetailCommand.ProductName,
                ProductPrice = createOrderDetailCommand.ProductPrice,
                Quantity = createOrderDetailCommand.Quantity,
                TotalPrice = createOrderDetailCommand.TotalPrice,
                OrderID = createOrderDetailCommand.OrderID
            });
        }
    }
}
