using System;
using System.Collections.Generic;
using Paneleo.Models.Model.Product;

namespace Paneleo.Models.Model.Order
{
    public class Order : Entity
    {
        public string Name { get; set; }
        public string Place { get; set; }
        public int ContractorId { get; set; }
        public virtual Contractor.Contractor Contractor { get; set; }
        public virtual ICollection<OrderProduct> Products { get; set; }
        public double NetPrice { get; set; }
        public double GrossPrice { get; set; }

    }
}