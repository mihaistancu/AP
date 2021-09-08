using AP.Processing.Async;
using AP.Processing.Sync;
using AP.Signals;
using System;

namespace AP.Processing
{
    public class Controller
    {
        private Pipeline pipeline;
        private Workflow workflow;
        private MessageBroker broker;
        private IErrorFactory errorFactory;
        private IReceiptFactory receiptFactory;

        public bool ReturnReceipt { get; set; }

        public Controller(
            Pipeline pipeline,
            Workflow workflow,
            MessageBroker broker,
            IErrorFactory errorFactory,
            IReceiptFactory receiptFactory)
        {
            this.pipeline = pipeline;
            this.workflow = workflow;
            this.broker = broker;
            this.errorFactory = errorFactory;
            this.receiptFactory = receiptFactory;
        }

        public string Handle(Message message)
        {
            try
            {
                pipeline.Process(message);
                var worker = workflow.GetFirst();
                broker.Send(worker, workflow, message);
            }
            catch (Exception exception)
            {
                return errorFactory.Get(exception, message);
            }

            return receiptFactory.Get(message);
        }
    }
}