using Application.Features.Mediator.Queries.OrderQueries;
using Application.Features.Mediator.Results.OrderResults;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.Mediator.Handlers.OrderHandlers
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, GetOrderByIdQueryResult>
    {
        private readonly IRepository<Order> _repository;

        public GetOrderByIdQueryHandler(IRepository<Order> repository)
        {
            _repository = repository;
        }

        public async Task<GetOrderByIdQueryResult> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAsync(request.Id);

            return new GetOrderByIdQueryResult
            {
                OrderID = values.OrderID,
                UserID = values.UserID,
                TotalPrice = values.TotalPrice,
                OrderDate = values.OrderDate,
            };
        }
    }
}
