using System;

namespace AP.Receiver.Responders
{
    public class ErrorOnlyResponder : IResponder
    {
        public string Error(Exception exception)
        {
            throw new NotImplementedException();
        }

        public string Receipt()
        {
            throw new NotImplementedException();
        }
    }
}
