using AP.Receiver;
using AP.Tests.TestDoubles;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AP.Tests
{
    [TestClass]
    public class PipelineTests
    {
        private Pipeline pipeline;

        [TestInitialize]
        public void Initialize()
        {
            pipeline = new Pipeline();
        }

        [TestMethod]
        public void CanTriggerDifferentProcessingSteps()
        {
            var handler1 = new HandlerSpy();
            pipeline.Add(handler1);

            var handler2 = new HandlerSpy();
            pipeline.Add(handler2);

            var message = new Message();
            pipeline.Process(message);

            Assert.IsTrue(handler1.HandleWasCalled);
            Assert.IsTrue(handler2.HandleWasCalled);
        }

        [TestMethod]
        public void StopsWhenGivenHandlerDecides()
        {
            var pipeline = new Pipeline();

            var handler1 = new HandlerSpy();
            handler1.Returns = false;
            pipeline.Add(handler1);

            var handler2 = new HandlerSpy();
            pipeline.Add(handler2);

            var message = new Message();
            pipeline.Process(message);

            Assert.IsTrue(handler1.HandleWasCalled);
            Assert.IsFalse(handler2.HandleWasCalled);
        }
    }
}
