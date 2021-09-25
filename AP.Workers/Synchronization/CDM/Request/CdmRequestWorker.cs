using AP.Messaging;

namespace AP.Workers.Synchronization.CDM.Request
{
    public class CdmRequestWorker : IWorker
    {
        private ICdmProvider provider;

        public CdmRequestWorker(ICdmProvider provider)
        {
            this.provider = provider;
        }

        public virtual bool Handle(Message message)
        {
            provider.Respond(message);
            return true;
        }
    }
}
