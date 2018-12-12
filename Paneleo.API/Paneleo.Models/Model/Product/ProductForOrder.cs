using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Paneleo.Models.Model.Product
{
    public class ProductForOrder 
    {
        public ProductOrder ProductId { get; set; }
        public double QuantityOrder { get; set; }
        public double TotalPrice { get; set; }
    }
}
