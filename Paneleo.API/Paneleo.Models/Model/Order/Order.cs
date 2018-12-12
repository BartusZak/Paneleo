using System;
using System.Collections.Generic;
using Paneleo.Models.Model.Product;

namespace Paneleo.Models.Model.Order
{
    public class Order : Entity
    {
        public int OrderId { get; set; }
        public string Place { get; set; }
        public virtual Contractor.Contractor Contractor { get; set; }
        public virtual ICollection<OrderProduct> Products { get; set; }
        public double TotalPrice { get; set; }

    }
}