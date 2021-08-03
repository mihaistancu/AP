using AP.Receiver;
using System;

namespace AP.Tests.TestDoubles
{
    public class ResponderStub : IResponder
    {
        public string Response { get; set; }

        public string Ok()
        {
            return Response;    
        }

        public string Error(Exception exception)
        {
            return Response;
        }
    }
}