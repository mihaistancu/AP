using AP.Sync;
using System;

namespace AP.Tests.TestDoubles
{
    public class ResponderStub : ISignal
    {
        public string ReceiptMessage { get; set; }

        public string Receipt()
        {
            return ReceiptMessage;    
        }

        public string ErrorMessage { get; set; }

        public string Error(Exception exception)
        {
            return ErrorMessage;
        }
    }
}