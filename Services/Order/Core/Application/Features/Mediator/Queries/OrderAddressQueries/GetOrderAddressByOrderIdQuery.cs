using Application.Features.Mediator.Results.OrderAddressResults;
using MediatR;

namespace Application.Features.Mediator.Queries.OrderAddressQueries
{
    public class GetOrderAddressByOrderIdQuery : IRequest<GetOrderAddressByOrderIdQueryResult>
    {
        public string Id { get; set; }

        public GetOrderAddressByOrderIdQuery(string id)
        {
            Id = id;
        }
    }
}
