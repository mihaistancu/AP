using AP.Messages;

namespace AP.Workers.Synchronization.CDM.Request
{
    public interface ICdmProvider
    {
        void Respond(Message request);
    }
}
