using MediatR;

namespace Application.Features.Mediator.Commands.OrderCommands
{
    public class DeleteOrderCommand : IRequest
    {
        public string Id { get; set; }

        public DeleteOrderCommand(string id)
        {
            Id = id;
        }
    }
}
