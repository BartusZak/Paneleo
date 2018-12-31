using Paneleo.Models.Model;

namespace Paneleo.Models.ModelDto
{
    public class ProductDetailedDto : Entity
    {
        public string Name { get; set; }
        public string Brand { get; set; }
        public double ProductQuantity { get; set; }
        public string UnitOfMeasure { get; set; }
        public double PricePerUnit { get; set; }
    }
}