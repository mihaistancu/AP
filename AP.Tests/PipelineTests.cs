using AP.Tests.TestDoubles;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AP.Tests
{
    [TestClass]
    public class PipelineTests
    {
        [TestMethod]
        public void CanTriggerDifferentProcessingSteps()
        {
            var pipeline = new Pipeline();

            var handler1 = new HandlerSpy();
            pipeline.Add(handler1);

            var handler2 = new HandlerSpy();
            pipeline.Add(handler2);

            var message = new Message();
            pipeline.Process(message);

            Assert.IsTrue(handler1.WasCalled);
            Assert.IsTrue(handler2.WasCalled);
        }
    }
}
