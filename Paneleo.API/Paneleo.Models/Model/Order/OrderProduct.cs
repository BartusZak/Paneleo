using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Paneleo.Models.Model.Product;

namespace Paneleo.Models.Model.Order
{
    public class OrderProduct :Entity
    {
        public double Quantity { get; set; }
        public double TotalNetPrice { get; set; }
        public double TotalGrossPrice{ get; set; }
        public int ProductId { get; set; }
        public Product.Product Product { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }

    }
}
