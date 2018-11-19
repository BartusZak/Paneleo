using System.ComponentModel.DataAnnotations;

namespace Paneleo.API.Services.Interfaces
{
    public class AddProductBindingModel
    {
        [Required]
        public string Name { get; set; }
        public int Quantity { get; set; }

    }
}