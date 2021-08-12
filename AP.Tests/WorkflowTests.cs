using AP.Processing;
using AP.Tests.TestDoubles;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AP.Tests
{
    [TestClass]
    public class WorkflowTests
    {
        private MessageBrokerSpy broker;
        private WorkerSequence sequence;
        private IWorker worker1;
        private IWorker worker2;
        private IWorker worker3;
        private LinearWorkflow workflow;
        
        [TestInitialize]
        public void Initialize()
        {
            broker = new MessageBrokerSpy();
            worker1 = new WorkerSpy();
            worker2 = new WorkerSpy();
            worker3 = new WorkerSpy();
            sequence = new WorkerSequence(worker1, worker2, worker3);
            workflow = new LinearWorkflow(broker, sequence);
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
            workflow.Done(worker1, new WorkerOutput());
            Assert.AreEqual(worker2, broker.CalledWorker);

            workflow.Done(worker2, new WorkerOutput());
            Assert.AreEqual(worker3, broker.CalledWorker);
        }

        [TestMethod]
        public void DoneStopsWhenSequenceIsOver()
        {
            workflow.Done(worker3, new WorkerOutput());

            Assert.IsNull(broker.CalledWorker);
        }
    }
}
