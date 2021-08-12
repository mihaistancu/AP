using AP.Receiver;
using AP.Tests.TestDoubles;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AP.Tests
{
    [TestClass]
    public class ControllerTests
    {
        private PipelineSpy pipeline;
        private MessageBrokerSpy broker;
        private ResponderStub responder;
        private Controller controller;
        private Message message;

        [TestInitialize]
        public void Initialize()
        {
            pipeline = new PipelineSpy();
            broker = new MessageBrokerSpy();
            responder = new ResponderStub();
            controller = new Controller(pipeline, broker, responder);
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

            Assert.AreEqual(message, broker.SentMessage);
        }

        [TestMethod]
        public void ReturnsResponse()
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
