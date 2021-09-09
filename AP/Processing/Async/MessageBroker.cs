using AP.Data;
using AP.Processing.Async.Workflows;
using AP.Signals;
using System;

namespace AP.Processing.Async
{
    public abstract class MessageBroker
    {
        private IErrorFactory errorFactory;
        private MessageBuilder builder;
        private IMessageStorage storage;
        private ErrorWorkflow errorWorkflow;

        public MessageBroker(
            IErrorFactory errorFactory,
            MessageBuilder builder,
            IMessageStorage storage,
            ErrorWorkflow errorWorkflow)
        {
            this.errorFactory = errorFactory;
            this.builder = builder;
            this.storage = storage;
            this.errorWorkflow = errorWorkflow;
        }

        public void Handle(IWorker worker, Workflow workflow, Message message)
        {
            try
            {
                var messages = worker.Handle(message);

                if (!workflow.IsLast(worker))
                {
                    var nextWorker = workflow.GetNext(worker);
                    Send(nextWorker, workflow, messages);
                }
            }
            catch (Exception exception)
            {
                Handle(exception, message);
            }
        }

        private void Handle(Exception exception, Message message)
        {
            var error = errorFactory.Get(exception, message);
            builder.WithEnvelope(error);
            var errorMessage = builder.Build();
            storage.Save(errorMessage);
            var worker = errorWorkflow.GetFirst();
            Send(worker, errorWorkflow, errorMessage);
        }

        public abstract void Send(IWorker worker, Workflow workflow, params Message[] messages);
    }
}
