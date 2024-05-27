using Application.Features.Mediator.Commands.OrderCommands;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.Mediator.Handlers.OrderHandlers
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand>
    {
        private readonly IRepository<Order> _repository;

        public CreateOrderCommandHandler(IRepository<Order> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Order
            {
                UserID = request.UserID,
                TotalPrice = request.TotalPrice,
                OrderDate = request.OrderDate,
                Status = false
            });

            return Unit.Value;
        }
    }
}
