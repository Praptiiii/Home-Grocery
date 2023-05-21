using HomeGrocery.DAL.Models;
using System.Linq.Expressions;
namespace HomeGrocery.DAL.Repository.Interface
{
    public interface IUser
    {
        Task CreateAsync(User entity);
        Task<List<User>> GetAllAsync(Expression<Func<User, bool>> filter = null);
        Task<User> GetByIDAsync(Expression<Func<User, bool>> filter = null);
        Task UpdateAsync(User entity);
        Task RemoveAsync(User entity);
        Task SaveAsync();


    }
}
