using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Paneleo.Models.BindingModel.Contractor;
using Paneleo.Models.BindingModel.Product;

namespace Paneleo.Models.BindingModel.Order
{
    public class AddOrderBindingModel
    {
        public string Place { get; set; }
        public AddContractorBindingModel Contractor { get; set; }
        public List<AddProductForOrderBindingModel> Products { get; set; }
        public double TotalCost { get; set; }

    }
}