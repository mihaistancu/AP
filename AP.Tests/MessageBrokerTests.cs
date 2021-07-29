using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AP.Tests
{
    [TestClass]
    public class MessageBrokerTests
    {
        private MockPipeline pipeline;
        private MockMessageBroker broker;

        [TestInitialize]
        public void Initialize()
        {
            pipeline = new MockPipeline();
            broker = new MockMessageBroker();
            broker.Set(pipeline);
        }

        [TestMethod]
        public void CanTriggerDifferentProcessingSteps()
        {
            var handler1 = new SpyHandler();
            broker.Setup("step1", handler1);

            var handler2 = new SpyHandler();
            broker.Setup("step2", handler2);

            var request1 = new ProcessingRequest();
            request1.Step = "step1";
            broker.Send(request1);

            var request2 = new ProcessingRequest();
            request2.Step = "step2";
            broker.Send(request2);

            Assert.IsTrue(handler1.WasCalled);
            Assert.IsTrue(handler2.WasCalled);
        }

        [TestMethod]
        public void CallsPipelineToMoveToNextStep()
        {   
            var handler = new SpyHandler();
            broker.Setup("step", handler);
            
            var request = new ProcessingRequest();
            request.Step = "step";
            broker.Send(request);

            Assert.IsTrue(pipeline.WasCalled);
        }
    }
}
