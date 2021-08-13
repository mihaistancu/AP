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
        private LinearWorkflow workflow;
        
        [TestInitialize]
        public void Initialize()
        {
            broker = new MessageBrokerSpy();
            Context.MessageBroker = broker;
            worker1 = new WorkerSpy1();
            worker2 = new WorkerSpy2();
            sequence = new WorkerSequence(worker1, worker2);
            workflow = new LinearWorkflow(sequence);
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
        }

        [TestMethod]
        public void DoneStopsWhenSequenceIsOver()
        {
            workflow.Done(worker2, new WorkerOutput());

            Assert.IsNull(broker.CalledWorker);
        }
    }
}
