using AP.Data;
using AP.Signals;
using System;

namespace AP.Processing.Async
{
    public class ExceptionHandler
    {
        private readonly IErrorFactory errorFactory;

        public ExceptionHandler(IErrorFactory errorFactory)
        {
            this.errorFactory = errorFactory;
        }

        public void Handle(Exception exception, Message message)
        {
            var error = errorFactory.Get(exception, message);
            Console.WriteLine(error);
        }
    }
}
