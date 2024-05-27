using Application.Features.Mediator.Results.OrderResults;
using MediatR;

namespace Application.Features.Mediator.Queries.OrderQueries
{
    public class GetOrderByUserQuery : IRequest<List<GetOrderByUserQueryResult>>
    {
        public string Id { get; set; }

        public GetOrderByUserQuery(string id)
        {
            Id = id;
        }
    }
}
