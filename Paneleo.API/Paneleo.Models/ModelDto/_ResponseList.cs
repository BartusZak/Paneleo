using System;
using System.Collections.Generic;
using System.Text;

namespace Paneleo.Models.ModelDto
{
    public class ResponseList<T> where T : class
    {
        public IEnumerable<T> SuccessResult { get; set; }

        public bool ErrorOccurred => Errors.Count > 0;

        public IDictionary<string, List<string>> Errors;

        public ResponseList()
        {
            Errors = new Dictionary<string, List<string>>();
        }

        public void AddError(string key, string value)
        {
            if (!Errors.Keys.Contains(key))
            {
                Errors.Add(key, new List<string>());
            }
            Errors[key].Add(value);
        }


    }
}
