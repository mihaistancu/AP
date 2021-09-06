using System;

namespace AP.Sync
{
    public interface ISignal
    {
        string Receipt();
        string Error(Exception exception);
    }
}