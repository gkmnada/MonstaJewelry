using Application.Features.CQRS.Results.AddressResults;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Features.CQRS.Handlers.AddressHandlers
{
    public class GetAddressQueryHandler
    {
        private readonly IRepository<Address> _repository;

        public GetAddressQueryHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAddressQueryResult>> Handle()
        {
            var values = await _repository.ListAsync();

            return values.Select(x => new GetAddressQueryResult
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
                OrderNotes = x.OrderNotes
            }).ToList();
        }
    }
}
