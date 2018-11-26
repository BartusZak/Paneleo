using System.ComponentModel.DataAnnotations;

namespace Paneleo.Models.BindingModel
{
    public class AddProductBindingModel
    {
        [Required]
        public string Name { get; set; }
        public int Quantity { get; set; }

    }
}