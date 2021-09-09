using AP.Data;
using AP.Processing.Async;
using AP.Processing.Sync;
using AP.Signals;
using System;

namespace AP.Processing
{
    public class Controller
    {
        private MessageBroker broker;
        private IErrorFactory errorFactory;

        public Pipeline Pipeline { get; set; }
        public Workflow Workflow { get; set; }
        public IReceiptFactory ReceiptFactory { get; set; }

        public Controller(MessageBroker broker, IErrorFactory errorFactory)
        {
            this.broker = broker;
            this.errorFactory = errorFactory;
        }

        public virtual string Handle(Message message)
        {
            try
            {
                Pipeline.Process(message);
                var worker = Workflow.GetFirst();
                broker.Send(worker, Workflow, message);
            }
            catch (Exception exception)
            {
                return errorFactory.Get(exception, message);
            }

            return ReceiptFactory.Get(message);
        }
    }
}