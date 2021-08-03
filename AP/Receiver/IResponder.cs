using System;

namespace AP.Receiver
{
    public interface IResponder
    {
        string Receipt();
        string Error(Exception exception);
    }
}