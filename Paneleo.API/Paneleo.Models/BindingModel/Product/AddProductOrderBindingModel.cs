using System;
using System.Collections.Generic;
using System.Text;

namespace Paneleo.Models.BindingModel.Product
{
    public class AddProductOrderBindingModel
    {
        private string _name;
        public string Name
        {
            get => _name;
            set => _name = value.Trim().ToLower();
        }
        public double OrderQuantity { get; set; }
        public string UnitOfMeasure { get; set; }
        public double Vat { get; set; }
        public double NetPrice { get; set; }
        public double GrossPrice { get; set; }
        public double TotalNetPrice { get; set; }
        public double TotalGrossPrice { get; set; }
        public int? ProductId { get; set; }
    }
}
