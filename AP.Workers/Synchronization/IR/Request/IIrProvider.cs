using AP.Messages;

namespace AP.Workers.Synchronization.IR.Request
{
    public interface IIrProvider
    {
        void Respond(Message request);
    }
}