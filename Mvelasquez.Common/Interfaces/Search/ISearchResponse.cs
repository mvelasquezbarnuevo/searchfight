using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvelasquez.Common.Interfaces.Search
{
    public interface ISearchResponse
    {
        string SearchBy { get; set; }
        string EngineName { get; set; }
        long RecordsCount { get; set; }
        bool Success { get; }
    }
}
