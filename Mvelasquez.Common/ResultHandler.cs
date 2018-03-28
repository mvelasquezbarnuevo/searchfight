using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvelasquez.Common
{
    public class ResultHandler
    {
        public ItemResult getWinnerByPlugin(Response response, string engineName)
        {
            var winner = response.EngineResponses.Where(e => e.EngineName == engineName).OrderByDescending(o => o.RecordsCount).FirstOrDefault();
            return new ItemResult { Engine = winner.EngineName, SearchBy = winner.SearchBy };
        }

    }


    public class ItemResult
    {
        public string Engine { get; set; }
        public string RecordsCount { get; set; }
        public string SearchBy { get; set; }
    }
}
