using System;
using System.Collections.Generic;
using System.Text;

namespace Paneleo.Models.ModelDto.Product
{
    public class ProductOrderDto
    {
        private string _name;
        public string Name
        {
            get => _name;
            set => _name = value.Trim().ToLower();
        }
        public double Quantity { get; set; }
        public string UnitOfMeasure { get; set; }
        public double Vat { get; set; }
        public double NetPrice { get; set; }
        public double GrossPrice { get; set; }
        public double TotalNetPrice { get; set; }
        public double TotalGrossPrice { get; set; }
        public int? Id { get; set; }
    }
}
