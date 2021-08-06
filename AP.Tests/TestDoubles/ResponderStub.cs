using AP.Receiver;
using System;

namespace AP.Tests.TestDoubles
{
    public class ResponderStub : IResponder
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