using AP.Receiver;
using AP.Tests.TestDoubles;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AP.Tests
{
    [TestClass]
    public class ControllerTests
    {
        private PipelineSpy pipeline;
        private WorkflowSpy workflow;
        private ResponderStub responder;
        private Controller controller;
        private Message message;

        [TestInitialize]
        public void Initialize()
        {
            pipeline = new PipelineSpy();
            workflow = new WorkflowSpy();
            responder = new ResponderStub();
            controller = new Controller(pipeline, workflow, responder);
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
        public void ReturnsResponse()
        {
            responder.ReceiptMessage = "response";

            var response = controller.Handle(message);

            Assert.AreEqual("response", response);
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
