using System;
using System.Collections.Generic;
using System.Text;

namespace Paneleo.Models.ModelDto
{
    public class SearchResults<T>
    {
        public List<T> Results { get; set; }

        public int CurrentPage { get; set; }

        public int TotalPageCount { get; set; }

 
    }
}
