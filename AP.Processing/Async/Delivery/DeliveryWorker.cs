namespace AP.Processing.Async.Delivery
{
    public class DeliveryWorker : IWorker
    {
        private IGateway gateway;

        public DeliveryWorker(IGateway gateway)
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
