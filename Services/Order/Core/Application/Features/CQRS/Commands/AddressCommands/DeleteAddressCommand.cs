namespace Application.Features.CQRS.Commands.AddressCommands
{
    public class DeleteAddressCommand
    {
        public string Id { get; set; }

        public DeleteAddressCommand(string id)
        {
            Id = id;
        }
    }
}
