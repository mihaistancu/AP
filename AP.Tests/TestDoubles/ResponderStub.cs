using AP.Receiver;
using System;

namespace AP.Tests.TestDoubles
{
    public class ResponderStub : IResponder
    {
        public string OkMessage { get; set; }

        public string Ok()
        {
            return OkMessage;    
        }

        public string ErrorMessage { get; set; }

        public string Error(Exception exception)
        {
            return ErrorMessage;
        }
    }
}