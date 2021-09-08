using System;

namespace AP.Processing.Async
{
    public abstract class MessageBroker
    {
        private readonly ExceptionHandler exceptionHandler;

        public MessageBroker(ExceptionHandler exceptionHandler)
        {
            this.exceptionHandler = exceptionHandler;
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
                exceptionHandler.Handle(exception, message);
            }
        }

        public abstract void Send(IWorker worker, Workflow workflow, params Message[] messages);
    }
}
