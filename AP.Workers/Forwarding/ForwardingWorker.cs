using AP.Messages;

namespace AP.Workers.Forwarding
{
    public class ForwardingWorker : IWorker
    {
        private IGateway gateway;

        public ForwardingWorker(IGateway gateway)
        {
            this.gateway = gateway;
        }

        public virtual bool Handle(Message message)
        {
            gateway.Deliver(message);
            return true;
        }
    }
}
