using AP.Middleware.RabbitMQ.Serialization;
using AP.Processing;
using AP.Processing.Async;
using System;

namespace AP.Middleware.RabbitMQ
{
    public class RabbitMqOrchestrator : Orchestrator, IDisposable
    {
        private Broker broker;
        private Serializer serializer;

        public RabbitMqOrchestrator(
            IOrchestratorConfig config, 
            IMessageStorage storage,
            Broker broker,
            Serializer serializer) 
            : base(config, storage)
        {
            this.broker = broker;
            this.serializer = serializer;
        }

        public void Start()
        {
            broker.Handler = OnReceived;
            broker.Start();
        }

        private void OnReceived(byte[] bytes)
        {
            var (worker, message) = serializer.Deserialize(bytes);
            Handle(worker, message);
        }

        public override void Dispatch(IWorker worker, Message message)
        {
            var body = serializer.Serialize(worker, message);
            broker.Send(body);
        }

        public void Dispose()
        {
            broker.Dispose();
        }
    }
}
