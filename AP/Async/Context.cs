using System;

namespace AP.Async
{
    public class Context
    {
        public IWorker Worker { get; set; }
        public IWorkflow Workflow { get; set; }
        public ExceptionHandler ExceptionHandler { get; set; }

        public void Handle(Message message)
        {
            try
            {
                var messages = Worker.Handle(message);
                Workflow.Next(this, messages);
            }
            catch (Exception exception)
            {
                ExceptionHandler.Handle(exception, this);
            }
        }
    }
}
