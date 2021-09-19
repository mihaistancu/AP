using AP.Processing.Async.Synchronization;

namespace AP.Processing.Async.Forwarding
{
    public class ForwardingWorker<T> : IWorker where T: IGateway
    {
        private T gateway;

        public ForwardingWorker(T gateway)
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
