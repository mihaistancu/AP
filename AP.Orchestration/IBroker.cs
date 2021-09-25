using System;

namespace AP.Orchestration
{
    public interface IBroker
    {
        IDisposable Start(Action<byte[]> handler);

        void Send(byte[] bytes);
    }
}
