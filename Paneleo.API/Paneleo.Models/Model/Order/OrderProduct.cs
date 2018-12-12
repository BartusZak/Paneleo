using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Paneleo.Models.Model.Product;

namespace Paneleo.Models.Model.Order
{
    public class OrderProduct :Entity
    {
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }

        public int ProductId { get; set; }
        public virtual ProductForOrder Product{ get; set; }
    }
}
