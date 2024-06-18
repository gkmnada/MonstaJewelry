namespace Application.Features.CQRS.Queries.OrderDetailQueries
{
    public class GetOrderDetailQuery
    {
        public string Id { get; set; }

        public GetOrderDetailQuery(string id)
        {
            Id = id;
        }
    }
}
