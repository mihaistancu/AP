using AP.Processing;
using AP.Processing.Async;
using System;

namespace AP.Middleware.RabbitMQ
{
    public class RabbitMqOrchestrator : Orchestrator, IDisposable
    {
        private MessageBroker broker;

        public RabbitMqOrchestrator(
            IOrchestratorConfig config, 
            IMessageStorage storage,
            MessageBroker broker) 
            : base(config, storage)
        {
            this.broker = broker;
        }

        public void Start()
        {
            broker.Handler = OnReceived;
            broker.Start();
        }

        private void OnReceived(IWorker worker, Message message)
        {
            Handle(worker, message);
        }

        public override void Dispatch(IWorker worker, Message message)
        {
            broker.Send(worker, message);
        }

        public void Dispose()
        {
            broker.Dispose();
        }
    }
}
