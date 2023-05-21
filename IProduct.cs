using HomeGrocery.DAL.Models;
using System.Linq.Expressions;

namespace HomeGrocery.DAL.Repository.Interface
{
    public interface IProduct
    {
        Task<List<Product>> GetAllAsync(Expression<Func<Product,bool>>filter = null);
        Task<Product> GetByIDAsync(Expression<Func<Product,bool>> filter = null);
        
        Task CreateAsync(Product entity);
        Task UpdateAsync(Product entity);
        Task RemoveAsync(Product entity);
        Task SaveAsync();

    }
}
