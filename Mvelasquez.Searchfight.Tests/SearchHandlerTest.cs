using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Mvelasquez.Common.Interfaces;
using Mvelasquez.Common.Interfaces.Engine;
using Mvelasquez.Common.Interfaces.Search;
using Mvelasquez.Searchfight.ConsolePrg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvelasquez.Searchfight.Tests
{

    [TestClass]
    public class SearchHandlerTest
    {
        [TestMethod]
        public void GivenAtLeastOneAvailableEngineShouldSendSearchRequest()
        {
            Mock<IEngineLoader> engineLoader = new Mock<IEngineLoader>();
            Mock<IScreenHandler> screen = new Mock<IScreenHandler>();

            engineLoader.Setup(l => l.IsReady()).Returns(true);
            var sut = new ConsoleHandler(engineLoader.Object, screen.Object);
            sut.Start(new List<string> { ".net", "java" });

            engineLoader.Verify(e => e.SendRequest(It.IsAny<ISearchRequest>()), Times.Once);
        }


        [TestMethod]
        public void ValidateGivenOnlyOneSearchCriteriaThenEnginesWontBeLoaded()
        {
            Mock<IEngineLoader> engineLoader = new Mock<IEngineLoader>();
            Mock<IScreenHandler> screen = new Mock<IScreenHandler>();

            engineLoader.Setup(l => l.IsReady()).Returns(true);
            var sut = new ConsoleHandler(engineLoader.Object, screen.Object);
            sut.Start(new List<string> { "ONEWORD" });

            engineLoader.Verify(e => e.LoadPlugins(), Times.Never);
        }

    }
}
