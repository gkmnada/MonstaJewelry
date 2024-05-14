using Application.Features.CQRS.Commands.OrderDetailCommands;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class DeleteOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public DeleteOrderDetailCommandHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteOrderDetailCommand deleteOrderDetailCommand)
        {
            var values = await _repository.GetAsync(deleteOrderDetailCommand.Id);
            await _repository.DeleteAsync(values);
        }
    }
}
