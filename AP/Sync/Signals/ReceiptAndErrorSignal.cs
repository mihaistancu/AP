using System;

namespace AP.Sync.Signals
{
    public class ReceiptAndErrorSignal : ISignal
    {
        public string Error(Exception exception)
        {
            return "error";
        }

        public string Receipt()
        {
            return "receipt";
        }
    }
}
