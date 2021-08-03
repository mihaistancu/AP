using System;

namespace AP.Receiver
{
    public interface IResponder
    {
        string Ok();
        string Error(Exception exception);
    }
}