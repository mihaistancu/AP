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
            workflow.Next = new WorkerInputDummy ();
            workflow.Next.ProcessingStep = "step2";
            workflow.Set(broker);

            var output = new WorkerOutputDummy ();
            output.ProcessingStep = "step1";
            workflow.Done(output);

            Assert.AreEqual("step2", broker.Received.ProcessingStep);
        }
    }
}
