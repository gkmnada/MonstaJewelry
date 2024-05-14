using Application.Features.CQRS.Queries.OrderDetailQueries;
using Application.Features.CQRS.Results.OrderDetailResults;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class GetOrderDetailByIdQueryHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public GetOrderDetailByIdQueryHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task<GetOrderDetailByIdQueryResult> Handle(GetOrderDetailByIdQuery query)
        {
            var values = await _repository.GetAsync(query.Id);

            return new GetOrderDetailByIdQueryResult
            {
                OrderDetailID = values.OrderDetailID,
                ProductID = values.ProductID,
                ProductName = values.ProductName,
                ProductPrice = values.ProductPrice,
                Quantity = values.Quantity,
                TotalPrice = values.TotalPrice,
                OrderID = values.OrderID
            };
        }
    }
}
