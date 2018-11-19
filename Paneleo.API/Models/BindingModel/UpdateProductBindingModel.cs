using System.ComponentModel.DataAnnotations;

namespace Paneleo.API.Services.Interfaces
{
    public class UpdateProductBindingModel : AddProductBindingModel
    {
        [Required]
        public int Id { get; set; }
    }
}