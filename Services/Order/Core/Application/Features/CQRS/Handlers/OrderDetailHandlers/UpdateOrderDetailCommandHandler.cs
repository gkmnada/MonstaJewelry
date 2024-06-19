using Application.Features.CQRS.Commands.OrderDetailCommands;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class UpdateOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public UpdateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateOrderDetailCommand updateOrderDetailCommand)
        {
            var values = await _repository.GetAsync(updateOrderDetailCommand.OrderDetailID);

            values.ProductID = updateOrderDetailCommand.ProductID;
            values.ProductName = updateOrderDetailCommand.ProductName;
            values.ProductPrice = updateOrderDetailCommand.ProductPrice;
            values.ProductImage = updateOrderDetailCommand.ProductImage;
            values.Quantity = updateOrderDetailCommand.Quantity;
            values.TotalPrice = updateOrderDetailCommand.TotalPrice;
            values.OrderID = updateOrderDetailCommand.OrderID;

            await _repository.UpdateAsync(values);
        }
    }
}
