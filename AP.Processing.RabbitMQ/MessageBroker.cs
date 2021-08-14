using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Threading.Tasks;

namespace AP.Processing.RabbitMQ
{
    public class MessageBroker : IMessageBroker, IDisposable
    {
        private readonly Serializer serializer;

        public MessageBroker(
            Serializer serializer)
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
            var work = serializer.Deserialize(e.Body.ToArray());
            await Task.Delay(250);
            work.Worker.Process(work);
        }
        
        public void Send(Work input)
        {
            var body = serializer.Serialize(input);
            using (var sendChannel = connection.CreateModel())
            {
                sendChannel.BasicPublish(
                    exchange: "",
                    routingKey: "hello",
                    basicProperties: null,
                    body: body);
            }
        }

        public void Dispose()
        {
            connection.Dispose();
            receiveChannel.Dispose();
        }
    }
}
