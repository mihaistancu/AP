using System;
using System.Collections.Generic;

namespace AP.Instrumentation
{
    public interface ITrace
    {
        IDisposable Start();
        IDisposable Start(string span);
        IDisposable Start<T>(string span, T carrier, Action<T, string, object> setter);
        IDisposable Start<T>(string span, T carrier, Func<T, string, IEnumerable<string>> getter);
    }
}
