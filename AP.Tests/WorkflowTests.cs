using AP.Processing;
using AP.Tests.TestDoubles;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AP.Tests
{
    [TestClass]
    public class WorkflowTests
    {
        private MessageBrokerSpy broker;
        private IWorker worker1;
        private IWorker worker2;
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
            workflow.Start(new Message());

            Assert.AreEqual(worker1, broker.CalledWorker);
        }

        [TestMethod]
        public void DoneSendsWorkToNextWorker()
        {
            workflow.Done(new Work { Worker = worker1 });

            Assert.AreEqual(worker2, broker.CalledWorker);
        }

        [TestMethod]
        public void DoneStopsWhenSequenceIsOver()
        {
            workflow.Done(new Work { Worker = worker2 });

            Assert.IsNull(broker.CalledWorker);
        }
    }
}
