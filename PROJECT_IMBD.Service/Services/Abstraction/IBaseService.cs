using PROJECT_IMDB.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PROJECT_IMBD.Service.Services.Abstraction
{
    public interface IBaseService<T> where T: BaseEntity
    {
        Task Add(T item);
        Task Add(List<T> items);

        Task Update(T item);

        Task Remove(int id);

        Task<T> GetById(int id);
        Task<T> GetByDefault(Expression<Func<T, bool>> exp);

        Task<List<T>> GetDefault(Expression<Func<T, bool>> exp);
        Task<List<T>> GetActive();
        Task<List<T>> GetAll();

        Task<bool> Any(Expression<Func<T, bool>> exp);

        Task<int> Save();
    }
}
