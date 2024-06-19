using Application.Features.Mediator.Queries.OrderAddressQueries;
using Application.Features.Mediator.Results.OrderAddressResults;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.Mediator.Handlers.OrderAddressHandlers
{
    public class GetOrderAddressByOrderIdQueryHandler : IRequestHandler<GetOrderAddressByOrderIdQuery, GetOrderAddressByOrderIdQueryResult>
    {
        private readonly IRepository<OrderAddress> _repository;

        public GetOrderAddressByOrderIdQueryHandler(IRepository<OrderAddress> repository)
        {
            _repository = repository;
        }

        public async Task<GetOrderAddressByOrderIdQueryResult> Handle(GetOrderAddressByOrderIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByFilterAsync(x => x.OrderID == request.Id);

            return new GetOrderAddressByOrderIdQueryResult
            {
                OrderAddressID = values.OrderAddressID,
                AddressID = values.AddressID,
                Name = values.Name,
                Surname = values.Surname,
                Email = values.Email,
                Phone = values.Phone,
                Country = values.Country,
                City = values.City,
                District = values.District,
                AddressDetail1 = values.AddressDetail1,
                AddressDetail2 = values.AddressDetail2,
                OrderID = values.OrderID
            };
        }
    }
}
