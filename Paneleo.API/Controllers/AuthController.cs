using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Paneleo.API.Data;
using Paneleo.API.Dtos;
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
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
        {

            userForRegisterDto.Username = userForRegisterDto.Username.ToLower();

            if (await _repo.UserExists(userForRegisterDto.Username))
                return BadRequest("Użytkownik już istnieje.");

            var userToCreate = new User
            {
                Username = userForRegisterDto.Username
            };

            var createdUser = await _repo.RegisterAsync(userToCreate, userForRegisterDto.Password);
            return StatusCode(201);

        }

    }
}