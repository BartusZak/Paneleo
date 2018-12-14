using System;
using System.Collections.Generic;
using System.Text;

namespace Paneleo.Models.ModelDto.Product
{
    public class ProductOrderDto
    {
        public double Quantity { get; set; }
        public double TotalCost { get; set; }
        public int ProductId { get; set; }
    }
}
