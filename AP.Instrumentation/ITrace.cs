using System;

namespace AP.Instrumentation
{
    public interface ITrace
    {
        IDisposable Start();
        IDisposable Start(string span);
    }
}
