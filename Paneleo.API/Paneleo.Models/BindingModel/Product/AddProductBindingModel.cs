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
        public string Brand { get; set; }
        public double Quantity { get; set; }
        public string UnitOfMeasure { get; set; }
        public double PriceOfUnit { get; set; }

    }
}