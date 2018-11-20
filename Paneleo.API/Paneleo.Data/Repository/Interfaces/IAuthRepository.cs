using System.Threading.Tasks;
using Paneleo.Models;

namespace Paneleo.Data.Repository.Interfaces
{
    public interface IAuthRepository
    {
        Task<User> RegisterAsync(User user, string password);
        Task<User> Login(string username, string password);
        Task<bool> UserExists(string username);
    }
}