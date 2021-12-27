using AP.Telemetry;
using System;

namespace AP.Observability
{
    public class Log : ILog
    {
        public void Debug(string message)
        {
            Console.WriteLine(message);
        }
    }
}
