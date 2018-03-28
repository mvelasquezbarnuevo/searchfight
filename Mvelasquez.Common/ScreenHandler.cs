using Mvelasquez.Common.Interfaces;
using Mvelasquez.Common.Interfaces.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvelasquez.Common
{
    public class ScreenHandler : IScreenHandler
    {
        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
            Console.ReadLine();
        }

        public void ShowResults(Response args, string[] names)
        {
            Console.WriteLine("RESULTS");
            var resultHandler = new ResultHandler();
            try
            {
                long totalMaxWinner = long.MinValue;
                foreach (var item in args.Criteria)
                {
                    var resultData = args.EngineResponses.FindAll(w => w.SearchBy == item);
                    var singleLine = $"    {item}: ";
                    foreach (var singleEngine in resultData)
                    {
                        if (totalMaxWinner < singleEngine.RecordsCount)
                            totalMaxWinner = singleEngine.RecordsCount;

                        singleLine += $"{singleEngine.EngineName}: {singleEngine.RecordsCount.ToString()} ";

                    }
                    Console.WriteLine(singleLine);
                }

                Console.WriteLine();
                foreach (var pluginName in names)
                {
                    var winnerByPlugin = resultHandler.getWinnerByPlugin(args, pluginName);
                    Console.WriteLine($"    { winnerByPlugin.Engine} winner: {winnerByPlugin.SearchBy}");

                }

                Console.WriteLine();
                var totalWinner = args.EngineResponses.Where(e => e.RecordsCount == totalMaxWinner).OrderByDescending(o => o.RecordsCount).FirstOrDefault();
                Console.WriteLine($"    Total winner: {totalWinner.SearchBy}");


            }
            catch (Exception ex)
            {
                throw ex;
            }

            Console.ReadLine();
        }

        public void ShowTitle()
        {
            Console.WriteLine("** SEARCH FIGHT **");
            Console.WriteLine();
        }
    }
}
