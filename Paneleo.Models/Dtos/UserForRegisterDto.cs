using System.ComponentModel.DataAnnotations;

namespace Paneleo.Models.Dtos
{
    public class UserForRegisterDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [StringLength(8, MinimumLength = 4, ErrorMessage = "Hasło musi mieć od 4 do 8 znaków!")]
        public string Password { get; set; }
    }
}