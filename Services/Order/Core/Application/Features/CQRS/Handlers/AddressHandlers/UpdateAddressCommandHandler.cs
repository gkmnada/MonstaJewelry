using Application.Features.CQRS.Commands.AddressCommands;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Features.CQRS.Handlers.AddressHandlers
{
    public class UpdateAddressCommandHandler
    {
        private readonly IRepository<Address> _repository;

        public UpdateAddressCommandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateAddressCommand updateAddressCommand)
        {
            var values = await _repository.GetAsync(updateAddressCommand.AddressID);

            values.UserID = updateAddressCommand.UserID;
            values.Name = updateAddressCommand.Name;
            values.Surname = updateAddressCommand.Surname;
            values.Email = updateAddressCommand.Email;
            values.Phone = updateAddressCommand.Phone;
            values.Country = updateAddressCommand.Country;
            values.City = updateAddressCommand.City;
            values.District = updateAddressCommand.District;
            values.AddressDetail1 = updateAddressCommand.AddressDetail1;
            values.AddressDetail2 = updateAddressCommand.AddressDetail2;
            values.OrderNotes = updateAddressCommand.OrderNotes;

            await _repository.UpdateAsync(values);
        }
    }
}
