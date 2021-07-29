using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AP.Tests
{
    [TestClass]
    public class MessageBrokerTests
    {
        [TestMethod]
        public void CanTriggerScan()
        {
            var handler = new SpyHandler();
            var bridge = new MockMessageBroker();
            bridge.Setup("step", handler);

            var request = new ProcessingRequest();
            bridge.Send(request);

            Assert.IsTrue(handler.WasCalled);
        }
    }
}
