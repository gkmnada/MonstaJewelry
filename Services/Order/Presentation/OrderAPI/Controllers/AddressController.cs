using Application.Features.CQRS.Commands.AddressCommands;
using Application.Features.CQRS.Handlers.AddressHandlers;
using Application.Features.CQRS.Queries.AddressQueries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OrderAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly GetAddressQueryHandler _getAddressQueryHandler;
        private readonly CreateAddressCommandHandler _createAddressCommandHandler;
        private readonly UpdateAddressCommandHandler _updateAddressCommandHandler;
        private readonly DeleteAddressCommandHandler _deleteAddressCommandHandler;
        private readonly GetAddressByIdQueryHandler _getAddressByIdQueryHandler;
        private readonly GetAddressByUserQueryHandler _getAddressByUserQueryHandler;

        public AddressController(GetAddressQueryHandler getAddressQueryHandler, CreateAddressCommandHandler createAddressCommandHandler, UpdateAddressCommandHandler updateAddressCommandHandler, DeleteAddressCommandHandler deleteAddressCommandHandler, GetAddressByIdQueryHandler getAddressByIdQueryHandler, GetAddressByUserQueryHandler getAddressByUserQueryHandler)
        {
            _getAddressQueryHandler = getAddressQueryHandler;
            _createAddressCommandHandler = createAddressCommandHandler;
            _updateAddressCommandHandler = updateAddressCommandHandler;
            _deleteAddressCommandHandler = deleteAddressCommandHandler;
            _getAddressByIdQueryHandler = getAddressByIdQueryHandler;
            _getAddressByUserQueryHandler = getAddressByUserQueryHandler;
        }

        [HttpGet]
        public async Task<IActionResult> ListAddress()
        {
            var values = await _getAddressQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("GetAddress")]
        public async Task<IActionResult> GetAddress(string id)
        {
            var values = await _getAddressByIdQueryHandler.Handle(new GetAddressByIdQuery(id));
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAddress(CreateAddressCommand createAddressCommand)
        {
            await _createAddressCommandHandler.Handle(createAddressCommand);
            return Ok("Başarılı");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAddress(UpdateAddressCommand updateAddressCommand)
        {
            await _updateAddressCommandHandler.Handle(updateAddressCommand);
            return Ok("Başarılı");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAddress(string id)
        {
            await _deleteAddressCommandHandler.Handle(new DeleteAddressCommand(id));
            return Ok("Başarılı");
        }

        [HttpGet("GetAddressByUser")]
        public async Task<IActionResult> GetAddressByUser(string id)
        {
            var values = await _getAddressByUserQueryHandler.Handle(new GetAddressByUserQuery(id));
            return Ok(values);
        }
    }
}
