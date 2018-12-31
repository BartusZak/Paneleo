using System;
using System.Collections.Generic;
using System.Text;
using Paneleo.Models.ModelDto.Contractor;
using Paneleo.Models.ModelDto.Order;
using Paneleo.Models.ModelDto.Product;

namespace Paneleo.Models.ModelDto.Dashboard
{
    public class DashboardStatisticsDto
    {
        public double TotalOrdersValue { get; set; }
        public int ContractorsCount { get; set; }
        public int OrdersCount { get; set; }
        public int ProductsCount { get; set; }
        public ICollection<ContractorShortDto> Contractors { get; set; }
        public ICollection<OrderShortDto> Orders{ get; set; }
        public ICollection<ProductShortDto> Products { get; set; }

    }
}
