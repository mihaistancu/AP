using AP.Orchestration;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AP.Broker
{
    public class RabbitMqBroker : IBroker
    {
        private IConnection connection;
        private IModel receiveChannel;

        public IDisposable Start(Action<Command> handler)
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
                var headers = args.BasicProperties.Headers == null
                   ? new Dictionary<string, object>()
                   : new Dictionary<string, object>(args.BasicProperties.Headers);

                return Task.Run(() => handler.Invoke(new Command
                {
                    Headers = headers,
                    Payload = args.Body.ToArray()
                }));
            };

            receiveChannel.BasicConsume(
                queue: "hello",
                autoAck: true,
                consumer: consumer);

            return new RabbitMqConnection(connection, receiveChannel);
        }

        public void Send(Command command)
        {
            using (var sendChannel = connection.CreateModel())
            {
                var properties = sendChannel.CreateBasicProperties();
                properties.Headers = command.Headers;

                sendChannel.BasicPublish(
                    exchange: "",
                    routingKey: "hello",
                    basicProperties: properties,
                    body: command.Payload);
            }
        }
    }
}
