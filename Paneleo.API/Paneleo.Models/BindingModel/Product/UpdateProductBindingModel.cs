using System.ComponentModel.DataAnnotations;

namespace Paneleo.Models.BindingModel
{
    public class UpdateProductBindingModel : AddProductBindingModel
    {
        [Required]
        public int Id { get; set; }
    }
}