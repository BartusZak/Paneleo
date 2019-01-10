using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Paneleo.Models.ModelDto.Product
{
    public class DetailsProductOrderDto
    {
        public string Name { get; set; }
        public double OrderQuantity { get; set; }
        public string UnitOfMeasure { get; set; }
        public double Vat { get; set; }
        public double NetPrice { get; set; }
        public double GrossPrice { get; set; }
        public double TotalNetPrice { get; set; }
        public double TotalGrossPrice { get; set; }
    }
}
