namespace Application.Features.CQRS.Commands.OrderDetailCommands
{
    public class DeleteOrderDetailCommand
    {
        public string Id { get; set; }

        public DeleteOrderDetailCommand(string id)
        {
            Id = id;
        }
    }
}
