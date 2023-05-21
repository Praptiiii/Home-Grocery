using HomeGrocery.DAL.Context;
using HomeGrocery.DAL.Models;
using HomeGrocery.DAL.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
namespace HomeGrocery.DAL.Repository.Implementation
{
    public class OrderRepo :IOrder
    {
        private readonly ApplicationDbContext _db;

        public OrderRepo(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task CreateAsync(Order entity)
        {

            await _db.Order.AddAsync(entity);
            await SaveAsync();

        }

        public async Task UpdateAsync(Order entity)
        {

            _db.Order.Update(entity);
            await SaveAsync();

        }

        public async Task<List<Order>> GetAllAsync(Expression<Func<Order, bool>> filter = null)
        {

            IQueryable<Order> query = _db.Order;

            if (filter != null)
            {
                query = query.Where(filter);
            }
            return await query.ToListAsync();

        }
        public async Task<Order> GetByIDAsync(Expression<Func<Order, bool>> filter = null)//, bool tracked = true/)
        {
            IQueryable<Order> query = _db.Order;

            

            if (filter != null)
            {
                query = query.Where(filter);
            }
            return await query.FirstOrDefaultAsync();

        }



        public async Task RemoveAsync(Order entity)
        {

            _db.Order.Remove(entity);
            await SaveAsync();


        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
