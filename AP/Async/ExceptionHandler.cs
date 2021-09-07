using System;

namespace AP.Async
{
    public class ExceptionHandler
    {
        public ExceptionHandler()
        {

        }

        public void Handle(Exception exception, Context context)
        {
            Console.WriteLine(exception);
        }
    }
}
