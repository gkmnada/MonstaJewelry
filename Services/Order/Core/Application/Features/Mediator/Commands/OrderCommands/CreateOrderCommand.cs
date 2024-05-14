using MediatR;

namespace Application.Features.Mediator.Commands.OrderCommands
{
    public class CreateOrderCommand : IRequest
    {
        public string UserID { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
