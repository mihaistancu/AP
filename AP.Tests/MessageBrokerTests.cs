using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AP.Tests
{
    [TestClass]
    public class MessageBrokerTests
    {
        [TestMethod]
        public void CanTriggerProcessingStep()
        {
            var handler = new SpyHandler();
            var broker = new MockMessageBroker();
            broker.Setup("step", handler);

            var request = new ProcessingRequest();
            broker.Send(request);

            Assert.IsTrue(handler.WasCalled);
        }


    }
}
