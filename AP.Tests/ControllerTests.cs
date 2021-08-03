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
        private Controller controller;

        [TestInitialize]
        public void Initialize()
        {
            pipeline = new PipelineSpy();
            workflow = new WorkflowSpy();
            controller = new Controller(pipeline, workflow);
        }

        [TestMethod]
        public void CallsPipeline()
        {
            var message = new Message();
            controller.Handle(message);

            Assert.IsTrue(pipeline.WasCalled);
        }

        [TestMethod]
        public void CallsWorkflow()
        {
            var message = new Message();
            controller.Handle(message);

            Assert.IsTrue(workflow.StartWasCalled);
        }
    }
}
