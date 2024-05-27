using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderContext _context;

        public OrderRepository(OrderContext context)
        {
            _context = context;
        }

        public async Task<List<Order>> ListOrderByUserAsync(string id)
        {
            var values = await _context.Orders.Where(x => x.UserID == id).ToListAsync();
            return values;
        }
    }
}
