using Mvelasquez.Common.Interfaces.Engine;
using Mvelasquez.Common.Interfaces;
using System.Collections.Generic;
using Mvelasquez.Common;
using System;

namespace Mvelasquez.Searchfight.ConsolePrg
{
    public class ConsoleHandler : IConsoleHandler
    {
        private readonly IEngineLoader _engineLoader;
        private readonly IScreenHandler _screen;


        public ConsoleHandler(IEngineLoader engineLoader,
                            IScreenHandler screen)
        {
            _engineLoader = engineLoader;
            _screen = screen;
        }




        public void Start(List<string> args)
        {
            args = new List<string>();
            args.Add(".net");
            //args.Add("java");

            _screen.ShowTitle();
            if (InputIsValid(args))
            {
                _engineLoader.LoadPlugins();
                if (_engineLoader.IsReady())
                {
                    var result = _engineLoader.SendRequest(new SearchRequest { Criteria = args }).Result;
                    //depending on consumer then output could be any other type like JSon
                    if (result != null)
                    {
                        _screen.ShowResults(result, GetNames(_engineLoader.GetAvailablePlugins()));
                    }
                }
                else
                {
                    _screen.ShowMessage("There was an error loading search plugins.");
                }
            }
            else {
                _screen.ShowMessage("There was an error with input data");
            }


        }

        private bool InputIsValid(List<string> args)
        {
            if (args == null) return false;
            if (args.Count == 0) return false;

            return true;
        }

        private string[] GetNames(List<EngineMapper> list)
        {
            List<string> values = new List<string>();
            foreach (var item in list)
            {
                values.Add(item.Name);
            }

            return values.ToArray();
        }


    }
}
