using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Paneleo.Models.Model;

namespace Paneleo.Data.Repository.Interfaces
{
    public interface IRepository<T> where T : Entity
    {
        Task<bool> AddAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<T> GetByAsync(Expression<Func<T, bool>> getBy, bool withTracking = true);
        Task<IQueryable<T>> GetAllAsync(bool withTracking = true);
        Task<IQueryable<T>> GetAllByAsync(Expression<Func<T, bool>> getBy, bool withTracking = true);
        Task<bool> RemoveAsync(T entity);
        Task<bool> ExistAsync(Expression<Func<T, bool>> getBy);
        Task<bool> IsEmptyAsync();
        void Detach(Entity entity);
    }
}