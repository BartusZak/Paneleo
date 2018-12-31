using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Paneleo.Models.Model;
using Paneleo.Models.Model.Contractor;
using Paneleo.Models.ModelDto.Product;

namespace Paneleo.Models.ModelDto
{
    public class OrderDetailedDto : Entity
    {
        public string Place { get; set; }
        public ContractorDto Contractor { get; set; }
        public ICollection<ProductOrderDto> Products { get; set; }
        public double TotalCost { get; set; }
    }
}