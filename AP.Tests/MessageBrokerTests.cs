using AP.Processing;
using AP.Tests.TestDoubles;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AP.Tests
{
    [TestClass]
    public class MessageBrokerTests
    {
        private WorkflowSpy workflow;
        private MessageBrokerDummy broker;

        [TestInitialize]
        public void Initialize()
        {
            workflow = new WorkflowSpy();
            broker = new MessageBrokerDummy();
            broker.Set(workflow);
        }

        [TestMethod]
        public void CanTriggerDifferentProcessingSteps()
        {
            var worker1 = new WorkerSpy();
            broker.Setup("step1", worker1);

            var worker2 = new WorkerSpy();
            broker.Setup("step2", worker2);

            var input1 = new WorkerInput();
            input1.ProcessingStep = "step1";
            broker.Send(input1);

            var input2 = new WorkerInput();
            input2.ProcessingStep = "step2";
            broker.Send(input2);

            Assert.IsTrue(worker1.ProcessWasCalled);
            Assert.IsTrue(worker2.ProcessWasCalled);
        }
    }
}
