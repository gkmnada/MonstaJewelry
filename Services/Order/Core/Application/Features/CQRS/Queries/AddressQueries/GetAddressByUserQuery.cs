namespace Application.Features.CQRS.Queries.AddressQueries
{
    public class GetAddressByUserQuery
    {
        public string UserID { get; set; }

        public GetAddressByUserQuery(string id)
        {
            UserID = id;
        }
    }
}
