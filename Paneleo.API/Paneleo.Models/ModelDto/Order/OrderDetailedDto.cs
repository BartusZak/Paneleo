using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Paneleo.Models.Model;
using Paneleo.Models.Model.Contractor;
using Paneleo.Models.ModelDto.Product;

namespace Paneleo.Models.ModelDto.Order
{
    public class OrderDetailedDto : Entity
    {
        public string Name { get; set; }
        public string Place { get; set; }
        public ContractorDto Contractor { get; set; }
        public ICollection<ProductOrderDto> Products { get; set; }
        public double NetPrice { get; set; }
        public double GrossPrice { get; set; }
    }
}