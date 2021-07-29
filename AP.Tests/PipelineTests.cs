using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AP.Tests
{
    [TestClass]
    public class PipelineTests
    {
        [TestMethod]
        public void CallsMessageBrokerForNextProcessingStep()
        {
            var broker = new SpyMessageBroker();
            var pipeline = new Pipeline();
            pipeline.Set(broker);

            var processingRequest = new ProcessingRequest();
            processingRequest.Step = "step";
            pipeline.Done(processingRequest);

            Assert.IsTrue(broker.WasCalled);
        }
    }
}
