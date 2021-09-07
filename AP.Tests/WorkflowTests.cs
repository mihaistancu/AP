using AP.Async;
using AP.Tests.TestDoubles;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AP.Tests
{
    [TestClass]
    public class WorkflowTests
    {
        private MessageBrokerSpy broker;
        private Worker worker1;
        private Worker worker2;
        private LinearWorkflow workflow;
        
        [TestInitialize]
        public void Initialize()
        {
            broker = new MessageBrokerSpy();
            worker1 = new WorkerSpy1();
            worker2 = new WorkerSpy2();
            workflow = new LinearWorkflow(broker, worker1, worker2);
        }

        [TestMethod]
        public void StartSendsWorkToFirstWorker()
        {
            workflow.Start(new Work());

            Assert.AreEqual(worker1, broker.CalledWorker);
        }

        [TestMethod]
        public void DoneSendsWorkToNextWorker()
        {
            workflow.Next(new Work { Worker = worker1 });

            Assert.AreEqual(worker2, broker.CalledWorker);
        }

        [TestMethod]
        public void DoneStopsWhenSequenceIsOver()
        {
            workflow.Next(new Work { Worker = worker2 });

            Assert.IsNull(broker.CalledWorker);
        }
    }
}
