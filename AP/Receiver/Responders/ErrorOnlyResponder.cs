using System;

namespace AP.Receiver.Responders
{
    public class ErrorOnlyResponder : IResponder
    {
        public string Error(Exception exception)
        {
            return "error";
        }

        public string Receipt()
        {
            return "empty";
        }
    }
}
