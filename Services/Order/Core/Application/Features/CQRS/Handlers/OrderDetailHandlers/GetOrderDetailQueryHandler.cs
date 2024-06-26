﻿using Application.Features.CQRS.Queries.OrderDetailQueries;
using Application.Features.CQRS.Results.OrderDetailResults;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class GetOrderDetailQueryHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public GetOrderDetailQueryHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetOrderDetailQueryResult>> Handle(GetOrderDetailQuery query)
        {
            var values = await _repository.ListByFilterAsync(x => x.OrderID == query.Id);

            return values.Select(x => new GetOrderDetailQueryResult
            {
                OrderDetailID = x.OrderDetailID,
                ProductID = x.ProductID,
                ProductName = x.ProductName,
                ProductPrice = x.ProductPrice,
                ProductImage = x.ProductImage,
                Quantity = x.Quantity,
                TotalPrice = x.TotalPrice,
                OrderID = x.OrderID
            }).ToList();
        }
    }
}
