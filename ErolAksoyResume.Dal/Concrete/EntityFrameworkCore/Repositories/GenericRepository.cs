using ErolAksoyResume.Dal.Concrete.EntityFrameworkCore.Context;
using ErolAksoyResume.Dal.Interfaces;
using ErolAksoyResume.Entities.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ErolAksoyResume.Dal.Concrete.EntityFrameworkCore.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class, ITable, new()
    {
        public async Task DeleteAsync(T entity)
        {
            using var context = new MyContext();
            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task<T> GetByFilterAsync(Expression<Func<T, bool>> filter)
        {
            using var context = new MyContext();
            return await context.Set<T>().FirstOrDefaultAsync(filter);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            using var context = new MyContext();
            return await context.Set<T>().FindAsync(id);
        }

        public async Task<List<T>> GetListAsync()
        {
            using var context = new MyContext();
            return await context.Set<T>().ToListAsync();
        }

        public async Task<List<T>> GetListByFilterAsync(Expression<Func<T, bool>> filter)
        {
            using var context = new MyContext();
            return await context.Set<T>().Where(filter).ToListAsync();
        }

        public async Task InsertAsync(T entity)
        {
            using var context = new MyContext();
            await context.Set<T>().AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            using var context = new MyContext();
            context.Set<T>().Update(entity);
            await context.SaveChangesAsync();
        }
    }
}
