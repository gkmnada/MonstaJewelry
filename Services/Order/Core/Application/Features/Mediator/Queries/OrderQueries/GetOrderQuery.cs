using Application.Features.Mediator.Results.OrderResults;
using MediatR;

namespace Application.Features.Mediator.Queries.OrderQueries
{
    public class GetOrderQuery : IRequest<List<GetOrderQueryResult>>
    {
    }
}
