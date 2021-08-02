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
            var handler1 = new HandlerSpy();
            broker.Setup("step1", handler1);

            var handler2 = new HandlerSpy();
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
        public void CallsWorkflowToMoveToNextStep()
        {   
            var handler = new HandlerSpy();
            broker.Setup("step", handler);
            
            var request = new ProcessingRequest();
            request.Step = "step";
            broker.Send(request);

            Assert.IsTrue(workflow.WasCalled);
        }
    }
}
