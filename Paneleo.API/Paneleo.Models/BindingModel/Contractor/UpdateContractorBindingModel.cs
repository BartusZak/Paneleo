using System.ComponentModel.DataAnnotations;

namespace Paneleo.Models.BindingModel
{
    public class UpdateContractorBindingModel : AddContractorBindingModel
    {
        [Required]
        public int Id { get; set; }
    }
}