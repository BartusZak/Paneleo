using System;
using System.Collections.Generic;

namespace Paneleo.Models.Model
{
    public class Order : Entity
    {
        public DateTime CreatedAt { get; set; }
        public string Place { get; set; }
        public Contractor Contractor { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public double ToPay { get; set; }

    }
}