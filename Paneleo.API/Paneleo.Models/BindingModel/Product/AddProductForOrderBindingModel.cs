using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Paneleo.Models.BindingModel.Product
{
    public class AddProductForOrderBindingModel
    {
        private string _name;
        [Required(ErrorMessage = "Nazwa jest wymagana!")]
        public string Name
        {
            get => _name;
            set => _name = value.Trim().ToLower();
        }
        public double QuantityOfProduct { get; set; }
        public string UnitOfMeasure { get; set; }
        public double CostOfOneUnit { get; set; }
        public double CostOfAllUnits { get; set; }
    }
}
