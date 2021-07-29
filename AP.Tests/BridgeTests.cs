using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AP.Tests
{
    [TestClass]
    public class BridgeTests
    {
        [TestMethod]
        public void CanTriggerScan()
        {
            var handler = new SpyHandler();
            var bridge = new Bridge();
            bridge.Setup("step", handler);

            var request = new ProcessingRequest();
            bridge.Send(request);

            Assert.IsTrue(handler.WasCalled);
        }
    }
}
