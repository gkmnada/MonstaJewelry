using Application.Features.Mediator.Queries.OrderQueries;
using Application.Features.Mediator.Results.OrderResults;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.Mediator.Handlers.OrderHandlers
{
    public class GetOrderQueryHandler : IRequestHandler<GetOrderQuery, List<GetOrderQueryResult>>
    {
        private readonly IRepository<Order> _repository;

        public GetOrderQueryHandler(IRepository<Order> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetOrderQueryResult>> Handle(GetOrderQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.ListAsync();

            return values.Select(x => new GetOrderQueryResult
            {
                OrderID = x.OrderID,
                UserID = x.UserID,
                TotalPrice = x.TotalPrice,
                OrderDate = x.OrderDate,
            }).ToList();
        }
    }
}
