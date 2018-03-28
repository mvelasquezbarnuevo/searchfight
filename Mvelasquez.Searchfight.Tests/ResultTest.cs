using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mvelasquez.Common;
using Mvelasquez.Common.Interfaces.Search;

namespace Mvelasquez.Searchfight.Tests
{
    [TestClass]
    public class ResultTest
    {
        [TestMethod]
        public void ShouldReturnWinnerBySearchEngine()
        {
            var response = new Response();
            response.Criteria = new List<string>() { ".net", "java" };
            response.EngineResponses = new List<ISearchResponse>();

            //var netMsn = new SearchResponse();
            //netMsn.EngineName = "Msn";
            //netMsn.RecordsCount = 10;
            //netMsn.SearchBy = ".net";
            //response.EngineResponses.Add(netMsn);


            var netGoogle = new SearchResponse();
            netGoogle.EngineName = "Google";
            netGoogle.RecordsCount = 2000;
            netGoogle.SearchBy = ".net";
            response.EngineResponses.Add(netGoogle);

            var netGoogle1 = new SearchResponse();
            netGoogle1.EngineName = "Google";
            netGoogle1.RecordsCount = 0;
            netGoogle1.SearchBy = "java";
            response.EngineResponses.Add(netGoogle1);

            var handler = new ResultHandler();
            var winner=  handler.getWinnerByPlugin(response, "Google");

            string expected = ".net";
            Assert.AreEqual(expected, winner.SearchBy);

        }
    }
}
