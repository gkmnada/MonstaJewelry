using Application.Features.Mediator.Results.OrderResults;
using MediatR;

namespace Application.Features.Mediator.Queries.OrderQueries
{
    public class GetOrderByIdQuery : IRequest<GetOrderByIdQueryResult>
    {
        public string Id { get; set; }

        public GetOrderByIdQuery(string id)
        {
            Id = id;
        }
    }
}
