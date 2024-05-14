using Application.Features.CQRS.Queries.AddressQueries;
using Application.Features.CQRS.Results.AddressResults;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Features.CQRS.Handlers.AddressHandlers
{
    public class GetAddressByIdQueryHandler
    {
        private readonly IRepository<Address> _repository;

        public GetAddressByIdQueryHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task<GetAddressByIdQueryResult> Handle(GetAddressByIdQuery query)
        {
            var values = await _repository.GetAsync(query.Id);

            return new GetAddressByIdQueryResult
            {
                AddressID = values.AddressID,
                UserID = values.UserID,
                Name = values.Name,
                Surname = values.Surname,
                Email = values.Email,
                Phone = values.Phone,
                Country = values.Country,
                City = values.City,
                District = values.District,
                AddressDetail1 = values.AddressDetail1,
                AddressDetail2 = values.AddressDetail2,
                OrderNotes = values.OrderNotes
            };
        }
    }
}
