using System.ComponentModel.DataAnnotations;

namespace Paneleo.Models.BindingModel
{
    public class AddContractorBindingModel
    {
        [Required(ErrorMessage = "Nazwa jest wymagana!")]
        public string Name { get; set; }
        public string NIP { get; set; }

    }
}