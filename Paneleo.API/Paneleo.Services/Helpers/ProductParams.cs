using System;
using System.Collections.Generic;
using System.Text;

namespace Paneleo.Services.Helpers
{
    public class ProductParams
    {
        private const int MaxPageSize = 50;
        public int PageNumber { get; set; } = 1;
        public int pageSize = 10;

        public int PageSize
        {
            get { return pageSize;}
            set { pageSize = (value > MaxPageSize) ? MaxPageSize : value; }

        }

    }
}
