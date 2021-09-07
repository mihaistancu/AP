﻿namespace AP.Async
{
    public class AsyncProcessor : IProcessor
    {
        private readonly WorkflowFactory factory;
        private readonly ExceptionHandler exceptionHandler;

        public AsyncProcessor(WorkflowFactory factory, ExceptionHandler exceptionHandler)
        {
            this.factory = factory;
            this.exceptionHandler = exceptionHandler;
        }

        public void Process(Message message)
        {
            var workflow = factory.Get(message.SedType);

            var context = new Context
            {   
                ExceptionHandler = exceptionHandler
            };
            workflow.Start(context, message);
        }
    }
}
