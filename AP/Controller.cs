using AP.Async;
using System;

namespace AP.Sync
{
    public class Controller
    {
        private Pipeline pipeline;
        private Workflow workflow;
        private ISignal signal;
        private MessageBroker broker;

        public Controller(
            Pipeline pipeline, 
            Workflow workflow, 
            ISignal signal, 
            MessageBroker broker)
        {
            this.pipeline = pipeline;
            this.workflow = workflow;
            this.signal = signal;
            this.broker = broker;
        }

        public string Handle(Message message)
        {
            try
            {
                pipeline.Process(message);
                var worker = workflow.GetFirst();
                broker.Send(worker, workflow, new[] { message });
            }
            catch (Exception exception)
            {
                return signal.Error(exception);
            }

            return signal.Receipt(message);
        }
    }
}