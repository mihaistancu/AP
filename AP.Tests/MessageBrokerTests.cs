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

            var input1 = new WorkerInputDummy ();
            input1.ProcessingStep = "step1";
            broker.Send(input1);

            var input2 = new WorkerInputDummy ();
            input2.ProcessingStep = "step2";
            broker.Send(input2);

            Assert.IsTrue(worker1.ProcessWasCalled);
            Assert.IsTrue(worker2.ProcessWasCalled);
        }

        [TestMethod]
        public void CallsWorkflowToMoveToNextStep()
        {   
            var worker = new WorkerSpy();
            broker.Setup("step", worker);
            
            var input = new WorkerInputDummy ();
            input.ProcessingStep = "step";
            broker.Send(input);

            Assert.IsTrue(workflow.DoneWasCalled);
        }
    }
}
