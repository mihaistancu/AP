using AP.Receiver;
using AP.Tests.TestDoubles;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AP.Tests
{
    [TestClass]
    public class ControllerTests
    {
        private PipelineSpy pipeline;
        private ResponderStub responder;
        private AsyncProcessorSpy processor;
        private Controller controller;
        private Message message;

        [TestInitialize]
        public void Initialize()
        {
            pipeline = new PipelineSpy();
            responder = new ResponderStub();
            processor = new AsyncProcessorSpy();
            controller = new Controller(pipeline, responder, processor);
            message = new Message();
        }

        [TestMethod]
        public void CallsPipeline()
        {
            controller.Handle(message);

            Assert.IsTrue(pipeline.ProcessWasCalled);
        }
        
        [TestMethod]
        public void CallsAsyncProcessor()
        {
            controller.Handle(message);

            Assert.IsTrue(processor.ProcessWasCalled);
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
