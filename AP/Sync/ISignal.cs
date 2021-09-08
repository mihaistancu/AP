using System;

namespace AP.Sync
{
    public interface ISignal
    {
        string Receipt(Message message);
        string Error(Exception exception);
    }
}