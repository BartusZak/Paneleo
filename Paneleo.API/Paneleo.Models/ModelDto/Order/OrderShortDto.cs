using System;
using System.Collections.Generic;
using System.Text;

namespace Paneleo.Models.ModelDto.Order
{
    public class OrderShortDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
