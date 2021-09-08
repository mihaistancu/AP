using System;

namespace AP.Sync.Signals
{
    public class ErrorOnlySignal : ISignal
    {
        public string Error(Exception exception)
        {
            return "error";
        }

        public string Receipt(Message message)
        {
            return "empty";
        }
    }
}
