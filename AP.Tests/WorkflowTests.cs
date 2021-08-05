using AP.Processing;
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
            workflow.Next = new WorkerInput();
            workflow.Next.ProcessingStep = "step2";
            workflow.Set(broker);

            var output = new WorkerOutput();
            output.ProcessingStep = "step1";
            workflow.Done(output);

            Assert.AreEqual("step2", broker.Received.ProcessingStep);
        }
    }
}
