using System;
using System.ComponentModel.DataAnnotations;

namespace Paneleo.Models.ModelDto
{
    public class OrderDetailedDto
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string ContractorName { get; set; }
        public double TotalCost { get; set; }
    }
}