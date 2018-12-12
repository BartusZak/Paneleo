using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Paneleo.Models.Model.Contractor
{
    public class Contractor :Entity
    {
        [Key]
        public int ContractorId { get; set; }
        public string Nip { get; set; }
        public string Regon { get; set; }
        public string ContractorName { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string Forename { get; set; }
        public virtual ICollection<Order.Order> Orders { get; set; }

    }
}
