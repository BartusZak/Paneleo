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
        public double PricePerUnit { get; set; }
        public double TotalCost { get; set; }
        public int? Id { get; set; }
    }
}
