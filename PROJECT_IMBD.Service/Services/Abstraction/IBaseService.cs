using PROJECT_IMDB.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace PROJECT_IMBD.Service.Services.Abstraction
{
    public interface IBaseService<T> where T: BaseEntity
    {
        void Add(T item);
        void Add(List<T> items);

        void Update(T item);

        void Remove(int id);

        T GetById(int id);
        T GetByDefault(Expression<Func<T, bool>> exp);

        List<T> GetDefault(Expression<Func<T, bool>> exp);
        List<T> GetActive();
        List<T> GetAll();

        bool Any(Expression<Func<T, bool>> exp);

        int Save();
    }
}
