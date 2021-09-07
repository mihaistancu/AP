using AP.Async;
using AP.Middleware.RabbitMQ.Serialization;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AP.Middleware.RabbitMQ
{
    public class RabbitMqMessageBroker : MessageBroker, IDisposable
    {   
        private readonly Serializer serializer;

        public RabbitMqMessageBroker(
            Serializer serializer, 
            ExceptionHandler exceptionHandler)
            : base(exceptionHandler)
        {
            this.serializer = serializer;
        }

        private IConnection connection;
        private IModel receiveChannel;

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
            var (context, message) = serializer.Deserialize(e.Body.ToArray());
            await Task.Delay(250);
            Handle(context, message);
        }

        public void Send(Context context, Message message)
        {
            var body = serializer.Serialize(context, message);
            using (var sendChannel = connection.CreateModel())
            {
                sendChannel.BasicPublish(
                    exchange: "",
                    routingKey: "hello",
                    basicProperties: null,
                    body: body);
            }
        }

        public override void Send(Context context, IEnumerable<Message> batch)
        {
            foreach (var message in batch)
            {
                Send(context, message);
            }
        }

        public void Dispose()
        {
            connection.Dispose();
            receiveChannel.Dispose();
        }
    }
}
