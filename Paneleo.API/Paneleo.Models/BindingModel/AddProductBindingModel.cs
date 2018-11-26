using System.ComponentModel.DataAnnotations;

namespace Paneleo.Models.BindingModel
{
    public class AddProductBindingModel
    {
        [Required(ErrorMessage = "Nazwa jest wymagana!")]
        public string Name { get; set; }
        public int Quantity { get; set; }

    }
}