using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Paneleo.Models.Model.Product
{
    public class Product : Entity
    {
        [Key]
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public int Quantity { get; set; }
        public string UnitOfMeasure { get; set; }
        public double PriceOfUnit { get; set; }
    }
}