using AP.Processing.Sync;
using AP.Tests.TestDoubles;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AP.Tests
{
    [TestClass]
    public class PipelineTests
    {
        [TestMethod]
        public void CallsGivenHandlers()
        {
            var handler1 = new HandlerSpy();
            var handler2 = new HandlerSpy();
            var pipeline = new Pipeline(handler1, handler2);
            
            var message = new Message();
            pipeline.Process(message);

            Assert.IsTrue(handler1.HandleWasCalled);
            Assert.IsTrue(handler2.HandleWasCalled);
        }

        [TestMethod]
        public void StopsWhenGivenHandlerDecides()
        {
            var handler1 = new HandlerSpy();
            handler1.Returns = false;
            var handler2 = new HandlerSpy();
            var pipeline = new Pipeline(handler1, handler2);

            var message = new Message();
            pipeline.Process(message);

            Assert.IsTrue(handler1.HandleWasCalled);
            Assert.IsFalse(handler2.HandleWasCalled);
        }
    }
}
