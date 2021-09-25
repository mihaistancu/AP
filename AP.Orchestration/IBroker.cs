using System;

namespace AP.Processing.Async
{
    public interface IBroker
    {
        void Start(Action<byte[]> handler);

        void Send(byte[] bytes);
    }
}
