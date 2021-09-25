using System;

namespace AP.Orchestration
{
    public interface IBroker
    {
        void Start(Action<byte[]> handler);

        void Send(byte[] bytes);
    }
}
