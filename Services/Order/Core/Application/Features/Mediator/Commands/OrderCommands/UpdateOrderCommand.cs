using MediatR;

namespace Application.Features.Mediator.Commands.OrderCommands
{
    public class UpdateOrderCommand : IRequest
    {
        public string OrderID { get; set; }
        public string UserID { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public bool Status { get; set; }
    }
}
