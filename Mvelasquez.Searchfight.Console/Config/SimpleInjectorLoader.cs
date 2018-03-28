using Mvelasquez.Common;
using Mvelasquez.Common.Interfaces;
using Mvelasquez.Searchfight.ConsolePrg;
using Mvelasquez.Searchfight.Core;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvelasquez.Searchfight.Console.Config
{
    class SimpleInjectorLoader
    {
        public static void Load(Container container)
        {

            var repositoryAssembly = typeof(EngineLoader).Assembly;

            var registrations =
                from type in repositoryAssembly.GetExportedTypes()
                where type.Namespace.Contains("Mvelasquez") || type.Namespace.Contains("Common")
                where type.GetInterfaces().Any()
                select new { Service = type.GetInterfaces().Single(), Implementation = type };

            foreach (var reg in registrations)
            {
                container.Register(reg.Service, reg.Implementation, Lifestyle.Transient);
            }

            //container.RegisterSingleton(LogManager.GetLogger(typeof(object)));
            container.Register<ConsoleHandler>();
            container.Register<IScreenHandler, ScreenHandler>();

            container.Verify();
        }
    }
}
