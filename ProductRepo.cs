using HomeGrocery.DAL.Context;
using HomeGrocery.DAL.Models;
using HomeGrocery.DAL.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace HomeGrocery.DAL.Repository.Implementation
{
    public class ProductRepo : IProduct
    {
        private readonly ApplicationDbContext _db;

        public ProductRepo(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task CreateAsync(Product entity)
        {

           await  _db.Product.AddAsync(entity);
           await SaveAsync();
           
        }

        public async Task<List<Product>> GetAllAsync(Expression<Func<Product,bool>> filter = null)
        {

            IQueryable<Product> query = _db.Product;

            if(filter != null)
            {
                query = query.Where(filter);
            }
            return await query.ToListAsync();

        }

        public async Task<Product> GetByIDAsync(Expression<Func<Product,bool>> filter = null)//, bool tracked = true/)
        {
            IQueryable<Product> query = _db.Product;

            /*if(!tracked)
            {
                query = query.AsNoTracking();
            }*/

            if(filter != null)
            {
                query = query.Where(filter);
            }
            return await query.FirstOrDefaultAsync();

            
            
        }

        /*public Task<Product> GetByIDAsync(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }*/

        public async Task RemoveAsync(Product entity)
        {
            
            _db.Product.Remove(entity);
            await SaveAsync();


        }

        
        public async Task UpdateAsync(Product entity)
        {

            _db.Product.Update(entity);
            await SaveAsync();

        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }

    }
}
