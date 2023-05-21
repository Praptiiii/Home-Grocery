using HomeGrocery.DAL.Context;
using HomeGrocery.DAL.Models;
using HomeGrocery.DAL.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace HomeGrocery.DAL.Repository.Implementation
{
    public class UserRepo :IUser
    {

        private readonly ApplicationDbContext _db;

        public UserRepo(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task CreateAsync(User entity)
        {
            await _db.User.AddAsync(entity);
            await SaveAsync();
        }

        public async Task<List<User>> GetAllAsync(Expression<Func<User, bool>> filter = null)
        {

            IQueryable<User> query = _db.User;

            if (filter != null)
            {
                query = query.Where(filter);
            }
            return await query.ToListAsync();

        }

        public async Task<User> GetByIDAsync(Expression<Func<User, bool>> filter = null)//, bool tracked = true/)
        {
            IQueryable<User> query = _db.User;

            /*if(!tracked)
            {
                query = query.AsNoTracking();
            }*/

            if (filter != null)
            {
                query = query.Where(filter);
            }
            return await query.FirstOrDefaultAsync();

        }

        public async Task RemoveAsync(User entity)
        {

            _db.User.Remove(entity);
            await SaveAsync();


        }

        public async Task UpdateAsync(User entity)
        {

            _db.User.Update(entity);
            await SaveAsync();

        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }




    }
}
