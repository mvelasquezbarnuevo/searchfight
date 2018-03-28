using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Mvelasquez.Common.Interfaces.Engine;

namespace Mvelasquez.Searchfight.Tests
{
    [TestClass]
    public class EngineTest
    {
        [TestMethod]
        public void IfThereAreNotPluginsLoadedThenLoaderShouldNotBeReady()
        {
            Mock<IEngineLoader> engineLoader = new Mock<IEngineLoader>();
            engineLoader.Object.Plugins = null;
            bool expected = false;
            var actual = engineLoader.Object.IsReady();

            Assert.AreEqual(expected, actual);

        }
    }
}
