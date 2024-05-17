using Application.Features.CQRS.Queries.AddressQueries;
using Application.Features.CQRS.Results.AddressResults;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Features.CQRS.Handlers.AddressHandlers
{
    public class GetAddressByUserQueryHandler
    {
        private readonly IRepository<Address> _repository;

        public GetAddressByUserQueryHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAddressByUserQueryResult>> Handle(GetAddressByUserQuery query)
        {
            var values = await _repository.ListByFilterAsync(x => x.UserID == query.UserID);

            return values.Select(x => new GetAddressByUserQueryResult
            {
                AddressID = x.AddressID,
                UserID = x.UserID,
                Name = x.Name,
                Surname = x.Surname,
                Email = x.Email,
                Phone = x.Phone,
                Country = x.Country,
                City = x.City,
                District = x.District,
                AddressDetail1 = x.AddressDetail1,
                AddressDetail2 = x.AddressDetail2,
                AddressTitle = x.AddressTitle,
            }).ToList();
        }
    }
}
