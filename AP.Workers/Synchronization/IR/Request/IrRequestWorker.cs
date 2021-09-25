using AP.Messages;

namespace AP.Workers.Synchronization.IR.Request
{
    public class IrRequestWorker : IWorker
    {
        private IIrProvider provider;

        public IrRequestWorker(IIrProvider provider)
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
