using System.Collections.Generic;
using System.Threading.Tasks;
using Paneleo.Models;

namespace Paneleo.Data.Repository.Interfaces
{
    public interface IPaneleoRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveAll();
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUser(int id);
    }
}