using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Threading.Tasks;

namespace AP.Middleware.RabbitMQ
{
    public class Broker: IDisposable
    {
        private IConnection connection;
        private IModel receiveChannel;
        
        public Action<byte[]> Handler { get; set; }

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
            e.Body.ToArray();
            Handler?.Invoke(e.Body.ToArray());
            await Task.CompletedTask;
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
