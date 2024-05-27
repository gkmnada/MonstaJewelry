using Application.Features.Mediator.Commands.OrderCommands;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.Mediator.Handlers.OrderHandlers
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand>
    {
        private readonly IRepository<Order> _repository;

        public UpdateOrderCommandHandler(IRepository<Order> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAsync(request.OrderID);

            values.UserID = request.UserID;
            values.TotalPrice = request.TotalPrice;
            values.OrderDate = request.OrderDate;
            values.Status = request.Status;

            await _repository.UpdateAsync(values);
            return Unit.Value;
        }
    }
}
