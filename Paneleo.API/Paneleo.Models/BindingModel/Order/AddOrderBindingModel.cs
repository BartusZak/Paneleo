using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Paneleo.Models.BindingModel.Contractor;
using Paneleo.Models.BindingModel.Product;
using Paneleo.Models.ModelDto.Product;

namespace Paneleo.Models.BindingModel.Order
{
    public class AddOrderBindingModel
    {
        public string Place { get; set; }
        [Required(ErrorMessage = "Kontrahent jest wymagany!")]
        public AddContractorBindingModel Contractor { get; set; }
        [Required(ErrorMessage = "Zamówienie musi składać się z min. 1 produktu!")]
        public ICollection<AddProductOrderBindingModel> Products { get; set; }
        public double NetPrice { get; set; }
        public double GrossPrice { get; set; }


    }
}