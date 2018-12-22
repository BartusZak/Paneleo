using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Paneleo.Models.Model.Contractor
{
    public class Contractor :Entity
    {
        public bool IsCompany { get; set; }
        public string Nip { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Street { get; set; }
        public string StreetNumber { get; set; }
        public string HouseNumber { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
        public string PostCity { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Www { get; set; }
        public virtual ICollection<Order.Order> Orders { get; set; }
    }
}
