using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvelasquez.Common.Interfaces.Search
{
    public interface ISearchRequest
    {

        string Address { get; set; }
        string SearchBy { get; set; }
        string ServiceApiAddress { get; }
        List<string> Criteria { get; set; }
    }
}
