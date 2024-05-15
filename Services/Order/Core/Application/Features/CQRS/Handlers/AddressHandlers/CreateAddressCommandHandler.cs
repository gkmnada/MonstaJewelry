using Application.Features.CQRS.Commands.AddressCommands;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Features.CQRS.Handlers.AddressHandlers
{
    public class CreateAddressCommandHandler
    {
        private readonly IRepository<Address> _repository;

        public CreateAddressCommandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateAddressCommand createAddressCommand)
        {
            await _repository.CreateAsync(new Address
            {
                UserID = createAddressCommand.UserID,
                Name = createAddressCommand.Name,
                Surname = createAddressCommand.Surname,
                Email = createAddressCommand.Email,
                Phone = createAddressCommand.Phone,
                Country = createAddressCommand.Country,
                City = createAddressCommand.City,
                District = createAddressCommand.District,
                AddressDetail1 = createAddressCommand.AddressDetail1,
                AddressDetail2 = createAddressCommand.AddressDetail2,
                AddressTitle = createAddressCommand.AddressTitle
            });
        }
    }
}
