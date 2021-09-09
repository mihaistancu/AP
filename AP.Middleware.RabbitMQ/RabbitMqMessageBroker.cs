using AP.Data;
using AP.Middleware.RabbitMQ.Serialization;
using AP.Processing.Async;
using AP.Processing.Async.Workflows;
using AP.Signals;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Threading.Tasks;

namespace AP.Middleware.RabbitMQ
{
    public class RabbitMqMessageBroker : MessageBroker, IDisposable
    {   
        private Serializer serializer;

        private IConnection connection;
        private IModel receiveChannel;

        public RabbitMqMessageBroker(
            IErrorFactory errorFactory, 
            MessageBuilder builder, 
            IMessageStorage storage, 
            ErrorWorkflow errorWorkflow,
            Serializer serializer) 
            : base(errorFactory, builder, storage, errorWorkflow)
        {
            this.serializer = serializer;
        }

        public void Connect()
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
            var (worker, workflow, message) = serializer.Deserialize(e.Body.ToArray());
            await Task.Delay(250);
            Handle(worker, workflow, message);
        }

        public void Send(IWorker worker, Workflow workflow, Message message)
        {
            var body = serializer.Serialize(worker, workflow, message);
            using (var sendChannel = connection.CreateModel())
            {
                sendChannel.BasicPublish(
                    exchange: "",
                    routingKey: "hello",
                    basicProperties: null,
                    body: body);
            }
        }

        public override void Send(IWorker worker, Workflow workflow, params Message[] messages)
        {
            foreach (var message in messages)
            {
                Send(worker, workflow, message);
            }
        }

        public void Dispose()
        {
            connection.Dispose();
            receiveChannel.Dispose();
        }
    }
}
