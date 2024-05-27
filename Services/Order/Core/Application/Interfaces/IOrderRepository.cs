using Domain.Entities;

namespace Application.Interfaces
{
    public interface IOrderRepository
    {
        Task<List<Order>> ListOrderByUserAsync(string id);
    }
}
