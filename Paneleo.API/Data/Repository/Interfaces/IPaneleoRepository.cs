using System.Collections.Generic;
using System.Threading.Tasks;
using Paneleo.API.Models;

namespace Paneleo.API.Data
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