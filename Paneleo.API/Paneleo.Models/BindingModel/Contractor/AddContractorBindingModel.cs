using System.ComponentModel.DataAnnotations;

namespace Paneleo.Models.BindingModel.Contractor
{
    public class AddContractorBindingModel
    {
        [Required(ErrorMessage = "Nazwa jest wymagana!")]
        public string Name { get; set; }
        public string Nip { get; set; }

    }
}