using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Paneleo.Models.Model.Product
{
    public class Product : Entity
    {
        public string Name { get; set; }
        public string Brand { get; set; }
        public double ProductQuantity { get; set; }
        public string UnitOfMeasure { get; set; }
        public double PricePerUnit { get; set; }
    }
}