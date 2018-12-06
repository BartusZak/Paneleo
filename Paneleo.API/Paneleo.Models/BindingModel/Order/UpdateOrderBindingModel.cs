using System.ComponentModel.DataAnnotations;

namespace Paneleo.Models.BindingModel
{
    public class UpdateOrderBindingModel : AddOrderBindingModel
    {
        [Required]
        public int Id { get; set; }
    }
}