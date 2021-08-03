using AP.Receiver;
using AP.Tests.TestDoubles;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AP.Tests
{
    [TestClass]
    public class ControllerTests
    {
        [TestMethod]
        public void CallsPipeline()
        {
            var pipeline = new Pipeline();

            var handler = new HandlerSpy();
            pipeline.Add(handler);
            var controller = new Controller(pipeline);

            var message = new Message();
            controller.Handle(message);

            Assert.IsTrue(handler.WasCalled);
        }
    }
}
