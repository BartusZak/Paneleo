using System.ComponentModel.DataAnnotations;

namespace Paneleo.Models.BindingModel
{
    public class AddProductBindingModel
    {
        private string _name;
        [Required(ErrorMessage = "Nazwa jest wymagana!")]
        public string Name
        {
            get => _name;
            set => _name = value.Trim().ToLower();
        }
        public int Quantity { get; set; }

    }
}