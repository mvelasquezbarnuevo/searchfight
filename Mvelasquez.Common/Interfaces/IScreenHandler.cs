using Mvelasquez.Common.Interfaces.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvelasquez.Common.Interfaces
{
    public interface IScreenHandler
    {
        void ShowTitle();
        void ShowResults(Response args, string[] engineLoader);

        void ShowMessage(string message);
    }
}
