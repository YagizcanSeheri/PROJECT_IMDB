using Microsoft.EntityFrameworkCore;
using PROJECT_IMBD.Service.Services.Abstraction;
using PROJECT_IMDB.DAL.Context;
using PROJECT_IMDB.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

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

        public void Add(T item)
        {
            _context.Set<T>().Add(item);
            Save();
        }

        public void Add(List<T> items)
        {
            _context.Set<T>().AddRange(items);
            Save();
        }

        public bool Any(Expression<Func<T, bool>> exp)
        {
            return _context.Set<T>().Any(exp);
        }

        public List<T> GetActive()
        {
            return _context.Set<T>().Where(x => x.Status != Status.Passive).ToList();
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetByDefault(Expression<Func<T, bool>> exp)
        {
            return _context.Set<T>().Where(exp).FirstOrDefault();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public List<T> GetDefault(Expression<Func<T, bool>> exp)
        {
            return _context.Set<T>().Where(exp).ToList();
        }


        public void Remove(int id)
        {
            T item = GetById(id);
            item.Status = Status.Passive;
            item.DeleteDate = DateTime.Now;
            Save();
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public void Update(T item)
        {
            T updateItem = GetById(item.Id);
            dbSet.Update(updateItem);
        }
    }
}

