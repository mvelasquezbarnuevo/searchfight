using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Mvelasquez.Searchfight.Engine.Bing
{
    [DataContract]
    public class MsnResponseContract
    {
        [DataMember]
        public WebPages webPages { get; set; }
    }

    [DataContract]
    public class WebPages
    {
        [DataMember]
        public string webSearchUrl { get; set; }
        [DataMember]
        public long totalEstimatedMatches { get; set; }
    }
}
