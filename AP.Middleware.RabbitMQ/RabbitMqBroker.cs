using AP.Orchestration;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Threading.Tasks;

namespace AP.Middleware.RabbitMQ
{
    public class RabbitMqBroker: IBroker, IDisposable
    {
        private IConnection connection;
        private IModel receiveChannel;

        public void Start(Action<byte[]> handler)
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
            consumer.Received += (sender, args) =>
            {
                return Task.Run(() => handler.Invoke(args.Body.ToArray()));
            };

            receiveChannel.BasicConsume(
                queue: "hello",
                autoAck: true,
                consumer: consumer);
        }

        public void Send(byte[] bytes)
        {   
            using (var sendChannel = connection.CreateModel())
            {
                sendChannel.BasicPublish(
                    exchange: "",
                    routingKey: "hello",
                    basicProperties: null,
                    body: bytes);
            }
        }

        public void Dispose()
        {
            connection.Dispose();
            receiveChannel.Dispose();
        }
    }
}
