using System.ComponentModel.DataAnnotations;

namespace Paneleo.Models.BindingModel.Contractor
{
    public class AddContractorBindingModel
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
    }
}