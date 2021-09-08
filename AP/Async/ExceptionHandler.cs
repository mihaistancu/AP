using System;

namespace AP.Async
{
    public class ExceptionHandler
    {
        public ExceptionHandler()
        {

        }

        public void Handle(Exception exception, Message message)
        {
            Console.WriteLine(exception);
        }
    }
}
