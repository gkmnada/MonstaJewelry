namespace Application.Features.CQRS.Queries.OrderDetailQueries
{
    public class GetOrderDetailByIdQuery
    {
        public string Id { get; set; }

        public GetOrderDetailByIdQuery(string id)
        {
            Id = id;
        }
    }
}
