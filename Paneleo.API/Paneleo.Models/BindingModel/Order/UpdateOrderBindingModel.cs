using System.ComponentModel.DataAnnotations;

namespace Paneleo.Models.BindingModel.Order

{
    public class UpdateOrderBindingModel : AddOrderBindingModel
    {
        [Required]
        public int Id { get; set; }
    }
}