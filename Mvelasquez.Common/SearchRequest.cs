﻿using Mvelasquez.Common.Interfaces.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvelasquez.Common
{
    public class SearchRequest : ISearchRequest
    {
        public string Address { get; set; }
        public string SearchBy { get; set; }

        public string ServiceApiAddress
        {
            get => $"{Address}{SearchBy}";
        }

        public List<string> Criteria { get; set; }


    }
}
