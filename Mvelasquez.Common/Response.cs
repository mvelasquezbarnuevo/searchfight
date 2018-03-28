using Mvelasquez.Common.Interfaces.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvelasquez.Common
{
    public class Response
    {
        public List<ISearchResponse> EngineResponses { get; set; }
        public List<string> Criteria { get; set; }

    }
}
