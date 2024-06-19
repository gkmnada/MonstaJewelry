using Application.Features.Mediator.Queries.OrderAddressQueries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OrderAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderAddressController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderAddressController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrderAddress(string id)
        {
            var query = new GetOrderAddressByOrderIdQuery(id);
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
