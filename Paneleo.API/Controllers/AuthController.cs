using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Paneleo.API.Data;
using Paneleo.API.Models;

namespace Paneleo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;

        public AuthController(IAuthRepository repo)
        {
            this._repo = repo;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(string username, string password)
        {

            username = username.ToLower();

            if (await _repo.UserExists(username))
                return BadRequest("Użytkownik już istnieje.");

            var userToCreate = new User
            {
                Username = username
            };

            var createdUser = await _repo.RegisterAsync(userToCreate, password);
            return StatusCode(201);

        }

    }
}