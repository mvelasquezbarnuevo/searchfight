using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mvelasquez.Common.Interfaces.Engine;
using Mvelasquez.Common.Interfaces.Search;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Reflection;
using System.ComponentModel.Composition;
using Mvelasquez.Common;
using System.Net.Http;

namespace Mvelasquez.Searchfight.Core
{
    public class EngineLoader : IEngineLoader
    {
        [ImportMany(typeof(IPluginComponent))]
        private IEnumerable<Lazy<IPluginComponent>> _plugins;

        private List<Error> _errors = new List<Error>();
        public IEnumerable<Lazy<IPluginComponent>> Plugins { get { return _plugins; } set { _plugins = value; } }

        public List<EngineMapper> GetAvailablePlugins()
        {
            var result = new List<EngineMapper>();
            foreach (Lazy<IPluginComponent> com in _plugins)
            {
                var descriptor = new EngineMapper
                {
                    Name = com.Value.Name
                };

                result.Add(descriptor);
            }
            return result;
        }

        public bool IsReady()
        {
            return _plugins.Any();
        }

        public void LoadPlugins()
        {
            try
            {
                var catalog = new AggregateCatalog();
                catalog.Catalogs.Add(
                    new DirectoryCatalog(
                        Path.GetDirectoryName(
                        Assembly.GetExecutingAssembly().Location
                        )
                    )
                );

                CompositionContainer container = new CompositionContainer(catalog);
                container.ComposeParts(this);
            }
            catch (Exception ex)
            {
                var error = new Error { Description = "SearchingCore: Search plugins couldn't be loaded." };
                _errors.Add(error);
                throw ex;
            }

        }

        public async Task<Response> SendRequest(ISearchRequest searchrequest)
        {
            try
            {
                var collectedResponses = new List<Task<ISearchResponse>>();

                foreach (var com in _plugins)
                    foreach (var query in searchrequest.Criteria)
                    {
                        var httpClient = new HttpClient();
                        collectedResponses.Add(com.Value.Search(query, httpClient));
                    }

                var searchResults = await Task.WhenAll(collectedResponses);
                return new Response { EngineResponses = searchResults.ToList(), Criteria = searchrequest.Criteria };

            }
            catch (Exception ex)
            {
                var error = new Error { Description = "SearchingCore: There's an error collecting plugins responses." };
                _errors.Add(error);
                throw ex;
            }

        }



    }
}
