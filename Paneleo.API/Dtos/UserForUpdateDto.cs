using System.ComponentModel.DataAnnotations;

namespace Paneleo.API.Dtos
{
    public class UserForUpdateDto
    {
        [Display(Name = "Nick")]
        public string knownAs { get; set; }

        [Display(Name = "Imię")]
        public string Name { get; set; }

        [Display(Name = "Nazwisko")]
        public string Forename { get; set; }

        [StringLength(18, ErrorMessage = "{0} musi mieć przynajmniej {2} znaków.", MinimumLength = 6)]
        [RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$")]
        [DataType(DataType.Password)]
        [Display(Name = "Hasło")]
        public string Password { get; set; }

        [StringLength(18, ErrorMessage = "{0} musi mieć przynajmniej {2} znaków.", MinimumLength = 6)]
        [RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$")]
        [DataType(DataType.Password)]
        [Display(Name = "Powtórzone hasło")]
        public string RepeatedPassword { get; set; }
    }
}