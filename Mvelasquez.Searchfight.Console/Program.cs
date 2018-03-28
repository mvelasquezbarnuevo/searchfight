using Mvelasquez.Searchfight.Console.Config;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvelasquez.Searchfight.ConsolePrg
{
    class Program
    {
        static readonly Container _container = new Container();
        static Program()
        {
            SimpleInjectorLoader.Load(_container);
        }
        static void Main(string[] args)
        {
            var handler = _container.GetInstance<ConsoleHandler>();
            handler.Start(args.ToList());
            //Console
        }
    }
}
