using System;
using System.Collections.Generic;
using System.Text;

namespace Paneleo.Models.BindingModel
{
    public class SearchParamsBindingModel
    {
        public int PageLimit { get; set; } = 10;
        public int PageNumber { get; set; } = 1;
    }
}
