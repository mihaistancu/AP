using AP.Middleware.RabbitMQ.Serialization;
using AP.Processing;
using AP.Processing.Async;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Threading.Tasks;

namespace AP.Middleware.RabbitMQ
{
    public class RabbitMqOrchestrator : Orchestrator, IDisposable
    {   
        private Serializer serializer;

        private IConnection connection;
        private IModel receiveChannel;

        public RabbitMqOrchestrator(
            IOrchestratorConfig config, 
            IMessageStorage storage,
            Serializer serializer) 
            : base(config, storage)
        {
            this.serializer = serializer;
        }

        public void Start()
        {
            var factory = new ConnectionFactory() { DispatchConsumersAsync = true };
            connection = factory.CreateConnection();
            receiveChannel = connection.CreateModel();

            receiveChannel.QueueDeclare(
                queue: "hello",
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            var consumer = new AsyncEventingBasicConsumer(receiveChannel);
            consumer.Received += OnReceived;

            receiveChannel.BasicConsume(
                queue: "hello",
                autoAck: true,
                consumer: consumer);
        }

        private async Task OnReceived(object sender, BasicDeliverEventArgs e)
        {
            var (worker, message) = serializer.Deserialize(e.Body.ToArray());
            Handle(worker, message);
            await Task.CompletedTask;
        }

        private void Send(IWorker worker, Message message)
        {
            var body = serializer.Serialize(worker, message);
            using (var sendChannel = connection.CreateModel())
            {
                sendChannel.BasicPublish(
                    exchange: "",
                    routingKey: "hello",
                    basicProperties: null,
                    body: body);
            }
        }

        public override void Dispatch(IWorker worker, params Message[] messages)
        {
            foreach (var message in messages)
            {
                Send(worker, message);
            }
        }

        public void Dispose()
        {
            connection.Dispose();
            receiveChannel.Dispose();
        }
    }
}
