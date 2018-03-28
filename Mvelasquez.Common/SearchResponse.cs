using Mvelasquez.Common.Interfaces.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvelasquez.Common
{
    public class SearchResponse : ISearchResponse
    {
        public string SearchBy { get; set; }
        public string EngineName { get; set; }
        public long RecordsCount { get; set; }
        public bool Success
        {
            get => RecordsCount > 0;
        }
        public Error Error { get; set; }

    }
}
