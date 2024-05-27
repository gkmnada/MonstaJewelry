using Application.Features.Mediator.Queries.OrderQueries;
using Application.Features.Mediator.Results.OrderResults;
using Application.Interfaces;
using MediatR;

namespace Application.Features.Mediator.Handlers.OrderHandlers
{
    public class GetOrderByUserQueryHandler : IRequestHandler<GetOrderByUserQuery, List<GetOrderByUserQueryResult>>
    {
        private readonly IOrderRepository _orderRepository;

        public GetOrderByUserQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<List<GetOrderByUserQueryResult>> Handle(GetOrderByUserQuery request, CancellationToken cancellationToken)
        {
            var values = await _orderRepository.ListOrderByUserAsync(request.Id);

            return values.Select(x => new GetOrderByUserQueryResult
            {
                OrderID = x.OrderID,
                UserID = x.UserID,
                TotalPrice = x.TotalPrice,
                OrderDate = x.OrderDate,
                Status = x.Status
            }).ToList();
        }
    }
}
