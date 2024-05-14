namespace Application.Features.Mediator.Results.OrderResults
{
    public class GetOrderQueryResult
    {
        public string OrderID { get; set; }
        public string UserID { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
