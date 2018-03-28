using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvelasquez.Common
{
    public static class Serializer
    {
        public static string ToJSon(object obj) {
            return JsonConvert.SerializeObject(obj);
        }
    }
}
