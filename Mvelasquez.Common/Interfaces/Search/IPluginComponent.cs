using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Mvelasquez.Common.Interfaces.Search
{
   public interface IPluginComponent
    {
        Task<ISearchResponse> Search(string query, HttpClient client);

        string Name { get; }
        string Address { get; }
    }
}
