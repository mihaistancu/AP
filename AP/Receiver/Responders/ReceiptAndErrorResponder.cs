using System;

namespace AP.Receiver.Responders
{
    public class ReceiptAndErrorResponder : IResponder
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
