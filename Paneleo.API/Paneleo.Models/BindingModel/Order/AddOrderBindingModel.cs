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
        public int ContractorId { get; set; }
        public ICollection<ProductOrderDto> Products { get; set; }
        public double TotalCost { get; set; }

        //public AddContractorBindingModel Contractor { get; set; }
        //public List<AddProductForOrderBindingModel> Products { get; set; }
    }
}