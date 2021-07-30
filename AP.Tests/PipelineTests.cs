using AP.Tests.TestDoubles;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AP.Tests
{
    [TestClass]
    public class PipelineTests
    {
        [TestMethod]
        public void CallsMessageBrokerForNextProcessingStep()
        {
            var broker = new MessageBrokerSpy();
            
            var pipeline = new PipelineStub();
            pipeline.Next = new ProcessingRequest();
            pipeline.Next.Step = "step2";
            pipeline.Set(broker);

            var processingRequest = new ProcessingRequest();
            processingRequest.Step = "step1";
            pipeline.Done(processingRequest);

            Assert.AreEqual("step2", broker.Received.Step);
        }
    }
}
