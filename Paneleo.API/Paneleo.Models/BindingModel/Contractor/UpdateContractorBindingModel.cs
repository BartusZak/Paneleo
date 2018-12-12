using System.ComponentModel.DataAnnotations;
using Paneleo.Models.BindingModel.Contractor;

namespace Paneleo.Models.BindingModel.Contractor
{
    public class UpdateContractorBindingModel : AddContractorBindingModel
    {
        [Required]
        public int Id { get; set; }
    }
}