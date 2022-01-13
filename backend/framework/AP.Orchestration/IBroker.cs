using System;

namespace AP.Orchestration
{
    public interface IBroker
    {
        IDisposable Start(Action<Command> handler);

        void Send(Command command);
    }
}
