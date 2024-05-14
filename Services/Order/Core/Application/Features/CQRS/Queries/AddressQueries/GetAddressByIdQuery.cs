namespace Application.Features.CQRS.Queries.AddressQueries
{
    public class GetAddressByIdQuery
    {
        public string Id { get; set; }

        public GetAddressByIdQuery(string id)
        {
            Id = id;
        }
    }
}
