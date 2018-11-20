using System.ComponentModel.DataAnnotations;

namespace Paneleo.Models.Dtos
{
    public class UserForUpdateDto
    {
        [Display(Name = "Nick")]
        public string KnownAs { get; set; }

        [Display(Name = "Imię")]
        public string Name { get; set; }

        [Display(Name = "Nazwisko")]
        public string Forename { get; set; }

        [StringLength(18, ErrorMessage = "{0} musi mieć od {2} do {1} znaków.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Hasło")]
        public string Password { get; set; }

        [StringLength(18, ErrorMessage = "{0} musi mieć od {2} do {1} znaków.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Powtórzone hasło")]
        public string RepeatedPassword { get; set; }
    }
}