using AP.Orchestration;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Threading.Tasks;

namespace AP.Middleware.RabbitMQ
{
    public class RabbitMqBroker: IBroker
    {
        private IConnection connection;
        private IModel receiveChannel;

        public IDisposable Start(Action<byte[]> handler)
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

            return new BrokerInternals(connection, receiveChannel);
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
    }
}
