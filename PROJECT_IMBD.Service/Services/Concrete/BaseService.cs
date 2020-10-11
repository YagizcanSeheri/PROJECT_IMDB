using Microsoft.EntityFrameworkCore;
using PROJECT_IMBD.Service.Services.Abstraction;
using PROJECT_IMDB.DAL.Context;
using PROJECT_IMDB.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PROJECT_IMBD.Service.Services.Concrete
{
    public class BaseService<T> : IBaseService<T> where T : BaseEntity
    {
        private static ProjectContext _context;
        private DbSet<T> dbSet { get; set; }
         
        public BaseService(ProjectContext context)
        {
            _context = context;
            dbSet = _context.Set<T>();
        }

        
        public async Task Add(T item)
        {
            await _context.Set<T>().AddAsync(item);
            await Save();
        }

        public async Task Add(List<T> items)
        {
           await _context.Set<T>().AddRangeAsync(items);
            await Save();
        }

        public async Task<bool> Any(Expression<Func<T, bool>> exp)
        {
            return await _context.Set<T>().AnyAsync(exp);
        }

        public async Task<List<T>> GetActive()
        {
            return await _context.Set<T>().Where(x => x.Status != Status.Passive).ToListAsync();
        }

        public async Task<List<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByDefault(Expression<Func<T, bool>> exp)
        {
            return await _context.Set<T>().Where(exp).FirstOrDefaultAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<List<T>> GetDefault(Expression<Func<T, bool>> exp)
        {
            return await _context.Set<T>().Where(exp).ToListAsync();
        }


        public async Task Remove(int id)
        {
            T item = await GetById(id);
            item.Status = Status.Passive;
            item.DeleteDate = DateTime.Now;
            await Save();
        }

        public async Task<int> Save()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task Update(T item)
        {
            T updateItem =await GetById(item.Id);
            dbSet.Update(updateItem);
        }
    }
}

