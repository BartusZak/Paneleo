using System;
using System.Collections.Generic;
using System.Text;
using Paneleo.Models.Model;

namespace Paneleo.Models.ModelDto.Product
{
    public class AddProductDto
    {
        public string Name { get; set; }
        public string Brand { get; set; }
        public double ProductQuantity { get; set; }
        public string UnitOfMeasure { get; set; }
        public double PricePerUnit { get; set; }
    }
}
