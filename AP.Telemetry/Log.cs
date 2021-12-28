using AP.Instrumentation;
using System;

namespace AP.Telemetry
{
    public class Log : ILog
    {
        public void Debug(string message)
        {
            Console.WriteLine(message);
        }
    }
}
