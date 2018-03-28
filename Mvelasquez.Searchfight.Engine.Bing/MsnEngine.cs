using Mvelasquez.Common;
using Mvelasquez.Common.Interfaces.Search;
using System;
using System.ComponentModel.Composition;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;

namespace Mvelasquez.Searchfight.Engine.Bing
{
    [Export(typeof(IPluginComponent))]
    public class MsnEngine: IPluginComponent
    {

        public string Name => "Msn search";
        public string Address => Properties.Resources.ADDRESS;
        private string Key => Properties.Resources.KEY;
        private string Header => Properties.Resources.HEADER;
        private string GetApiQuery(string query) => $"{Address}{query}";

        public async Task<ISearchResponse> Search(string query, HttpClient client)
        {

            using (var httpClient = new HttpClient())
            using (var response = await httpClient.SendAsync(GetRequestMessage(GetApiQuery(query))))
            {
                var streamContent = await response.Content.ReadAsStreamAsync();
                var jsonSerializer = new DataContractJsonSerializer(typeof(MsnResponseContract));
                var crudData = (MsnResponseContract)jsonSerializer.ReadObject(streamContent);

                if (crudData != null && crudData.webPages != null)
                {
                    return new SearchResponse
                    {
                        SearchBy = query,
                        EngineName = Name,
                        RecordsCount = crudData.webPages.totalEstimatedMatches
                    };
                }

            }

            return new SearchResponse
            {
                EngineName = Name,
                RecordsCount = 0,
                Error = new Error { Description = "Msn engine is not working" }
            };
        }

        private HttpRequestMessage GetRequestMessage(string apiQuery)
        {
            var request = new HttpRequestMessage
            {
                RequestUri = new Uri(apiQuery),
                Method = HttpMethod.Get,
            };
            request.Headers.Add(Header, Key);

            return request;
        }

    }
}
