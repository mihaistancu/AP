using System;
using System.Collections.Generic;

namespace AP.Async
{
    public abstract class MessageBroker
    {
        private readonly ExceptionHandler exceptionHandler;

        public MessageBroker(ExceptionHandler exceptionHandler)
        {
            this.exceptionHandler = exceptionHandler;
        }

        public void Handle(Context context, Message message)
        {
            try
            {   
                var messages = context.Worker.Handle(message);

                if (!context.Workflow.IsLast(context.Worker))
                {
                    context.Worker = context.Workflow.GetNext(context.Worker);
                    Send(context, messages);
                }
            }
            catch (Exception exception)
            {
                exceptionHandler.Handle(exception, context);
            }
        }

        public abstract void Send(Context context, IEnumerable<Message> messages);
    }
}
