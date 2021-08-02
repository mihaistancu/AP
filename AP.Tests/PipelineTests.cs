using AP.Tests.TestDoubles;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace AP.Tests
{
    [TestClass]
    public class PipelineTests
    {
        [TestMethod]
        public void CanCallDifferentOperations()
        {
            var pipeline = new Pipeline();

            var operation1 = new OperationSpy();
            pipeline.Add(operation1);

            var operation2 = new OperationSpy();
            pipeline.Add(operation2);

            var stream = new MemoryStream();
            pipeline.Process(stream);

            Assert.IsTrue(operation1.WasCalled);
            Assert.IsTrue(operation2.WasCalled);
        }
    }
}
