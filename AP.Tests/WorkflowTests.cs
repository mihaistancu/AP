using AP.Tests.TestDoubles;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AP.Tests
{
    [TestClass]
    public class WorkflowTests
    {
        [TestMethod]
        public void CallsMessageBrokerForNextProcessingStep()
        {
            var broker = new MessageBrokerSpy();
            
            var workflow = new WorkflowStub();
            workflow.Next = new ProcessingRequest();
            workflow.Next.Step = "step2";
            workflow.Set(broker);

            var processingRequest = new ProcessingRequest();
            processingRequest.Step = "step1";
            workflow.Done(processingRequest);

            Assert.AreEqual("step2", broker.Received.Step);
        }
    }
}
