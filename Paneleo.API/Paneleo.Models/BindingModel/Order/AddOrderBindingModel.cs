using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Paneleo.Models.BindingModel
{
    public class AddOrderBindingModel
    {
        public int Id { get; set; }
        public string Place { get; set; }
        public AddContractorBindingModel Contractor { get; set; }
        public IEnumerable<AddProductBindingModel> Products { get; set; }
        public double ToPay { get; set; }

    }
}