using AP.Sync;
using AP.Tests.TestDoubles;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AP.Tests
{
    [TestClass]
    public class ControllerTests
    {
        private ProcessorSpy syncProcessor;
        private SignalStub signal;
        private ProcessorSpy asyncProcessor;
        private Controller controller;
        private Message message;

        [TestInitialize]
        public void Initialize()
        {
            syncProcessor = new ProcessorSpy();
            signal = new SignalStub();
            asyncProcessor = new ProcessorSpy();
            controller = new Controller(syncProcessor, signal, asyncProcessor);
            message = new Message();
        }

        [TestMethod]
        public void CallsSyncProcessor()
        {
            controller.Handle(message);

            Assert.IsTrue(syncProcessor.ProcessWasCalled);
        }
        
        [TestMethod]
        public void CallsAsyncProcessor()
        {
            controller.Handle(message);

            Assert.IsTrue(asyncProcessor.ProcessWasCalled);
        }

        [TestMethod]
        public void ReturnsReceipt()
        {
            signal.ReceiptMessage = "receipt";

            var response = controller.Handle(message);

            Assert.AreEqual("receipt", response);
        }

        [TestMethod]
        public void ReturnsErrorWhenSyncProcessorFails()
        {
            syncProcessor.ThrowException = true;
            signal.ErrorMessage = "error";

            var response = controller.Handle(message);

            Assert.AreEqual("error", response);
        }

        [TestMethod]
        public void ReturnsErrorWhenAsyncProcessorFails()
        {
            asyncProcessor.ThrowException = true;
            signal.ErrorMessage = "error";

            var response = controller.Handle(message);

            Assert.AreEqual("error", response);
        }
    }
}
