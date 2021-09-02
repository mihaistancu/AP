using AP.Receiver;
using AP.Tests.TestDoubles;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AP.Tests
{
    [TestClass]
    public class ControllerTests
    {
        private PipelineSpy pipeline;
        private WorkflowFactoryStub factory;
        private WorkflowSpy workflow;
        private ResponderStub responder;
        private Controller controller;
        private Message message;

        [TestInitialize]
        public void Initialize()
        {
            pipeline = new PipelineSpy();
            responder = new ResponderStub();
            factory = new WorkflowFactoryStub();
            workflow = new WorkflowSpy();
            factory.Workflow = workflow;
            controller = new Controller(pipeline, responder, factory);
            message = new Message();
        }

        [TestMethod]
        public void CallsPipeline()
        {
            controller.Handle(message);

            Assert.IsTrue(pipeline.ProcessWasCalled);
        }
        
        [TestMethod]
        public void CallsWorkflow()
        {
            controller.Handle(message);

            Assert.IsTrue(workflow.StartWasCalled);
        }

        [TestMethod]
        public void ReturnsReceipt()
        {
            responder.ReceiptMessage = "receipt";

            var response = controller.Handle(message);

            Assert.AreEqual("receipt", response);
        }

        [TestMethod]
        public void ReturnsErrorOnException()
        {
            pipeline.ThrowException = true;
            responder.ErrorMessage = "error";

            var response = controller.Handle(message);

            Assert.AreEqual("error", response);
        }
    }
}
