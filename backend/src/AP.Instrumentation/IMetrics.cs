using System;

namespace AP.Instrumentation
{
    public interface IMetrics
    {
        IDisposable Start();
        void Observe<T>(string name, Func<T> getter) where T : struct;
    }
}
