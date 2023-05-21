using HomeGrocery.DAL.Models;
using System.Linq.Expressions;

namespace HomeGrocery.DAL.Repository.Interface
{
    public interface IOrder
    {
        Task CreateAsync(Order entity);
        Task UpdateAsync(Order entity);
        Task<List<Order>> GetAllAsync(Expression<Func<Order, bool>> filter = null);
        Task<Order> GetByIDAsync(Expression<Func<Order, bool>> filter = null);
        Task RemoveAsync(Order entity);
        Task SaveAsync();

    }
}
