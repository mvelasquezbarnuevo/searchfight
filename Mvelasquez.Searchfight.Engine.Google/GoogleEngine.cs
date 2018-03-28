using Mvelasquez.Common.Interfaces.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using Mvelasquez.Common;
using System.ComponentModel.Composition;

namespace Mvelasquez.Searchfight.Engine.Google
{
    [Export(typeof(IPluginComponent))]
    public class GoogleEngine : IPluginComponent, IDisposable
    {
        public string Name => "Google";
        public string Address => Properties.Resources.ADDRESS;
        private HttpClient _client;
        private string GetApiQuery(string query) => $"{Address}{query}";



        public async Task<ISearchResponse> Search(string query, HttpClient client)
        {
            _client = client;
            using (var response = await client.GetStreamAsync(GetApiQuery(query)))
            {
                var jsonSerializer = new DataContractJsonSerializer(typeof(GoogleResponseContract));
                var crudData = (GoogleResponseContract)jsonSerializer.ReadObject(response);

                if (crudData != null && crudData.queries != null && crudData.queries.request.Length > 0)
                {
                    return new SearchResponse
                    {
                        SearchBy = query,
                        EngineName = Name,
                        RecordsCount = crudData.queries.request[0].totalResults
                    };
                }

                return new SearchResponse
                {
                    EngineName = Name,
                    RecordsCount = 0,
                    Error = new Error { Description = "Google engine is not working" }
                };
            }



            return new SearchResponse
            {
                EngineName = Name,
                RecordsCount = 0
            };
        }

        public void Dispose()
        {
            _client = null;
        }
    }
}
