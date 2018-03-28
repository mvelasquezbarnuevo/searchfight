using Mvelasquez.Common.Interfaces.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvelasquez.Common.Interfaces.Engine
{
    public interface IEngineLoader
    {
        void LoadPlugins();
        bool IsReady();
        List<EngineMapper> GetAvailablePlugins();
        Task<Response> SendRequest(ISearchRequest searchrequest);

        IEnumerable<Lazy<IPluginComponent>> Plugins { get; set; }


    }
}
