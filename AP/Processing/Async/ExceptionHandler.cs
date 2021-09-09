using AP.Data;
using AP.Processing.Async.Workflows;
using AP.Signals;
using System;

namespace AP.Processing.Async
{
    public class ExceptionHandler
    {
        private IErrorFactory errorFactory;
        private MessageBuilder builder;
        private IMessageStorage storage;
        private MessageBroker broker;
        private ErrorWorkflow errorWorkflow;

        public ExceptionHandler(
            IErrorFactory errorFactory, 
            MessageBuilder builder,
            IMessageStorage storage,
            MessageBroker broker,
            ErrorWorkflow errorWorkflow)
        {
            this.errorFactory = errorFactory;
            this.builder = builder;
            this.storage = storage;
            this.broker = broker;
            this.errorWorkflow = errorWorkflow;
        }

        public void Handle(Exception exception, Message message)
        {
            var error = errorFactory.Get(exception, message);
            builder.WithEnvelope(error);
            var errorMessage = builder.Build();
            storage.Save(errorMessage);
            var worker = errorWorkflow.GetFirst();
            broker.Send(worker, errorWorkflow, errorMessage);
        }
    }
}
