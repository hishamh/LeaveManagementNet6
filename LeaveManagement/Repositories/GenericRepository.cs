using LeaveManagement.Contracts;
using LeaveManagement.Data;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagement.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        readonly ApplicationDbContext context;
        public GenericRepository(ApplicationDbContext context)
        {
            this.context = context;  

        }

        public async Task<T> AddAsync(T entity)
        {
            //await context.Set<T>().AddAsync(entity);
            //context.SaveChanges();

            await context.AddAsync(entity);
            context.SaveChanges();
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            var eneity = await GetAsync(id);
            context.Set<T>().Remove( eneity);
            await context.SaveChangesAsync();

        }

        public async Task<bool> Exists(int id)
        {
            var entity = await GetAsync(id);
            return entity != null;
        }

        public async Task<List<T>> GetAllAsync()
        {
           return await  context.Set<T>().ToListAsync();
        }

        public async Task<T> GetAsync(int? id)
        {

            if (id == null)
            {
                return null;
            }
            return await context.Set<T>().FindAsync(id);
        }

        public Task<T> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(T entity)
        {
          context.Update(entity);
            await context.SaveChangesAsync();
        }
    }
}
