using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Threading.Tasks;

namespace AP.Processing.RabbitMQ
{
    public class MessageBroker : IMessageBroker, IDisposable
    {
        private readonly WorkflowStore workflowStore;
        private readonly WorkerStore workerStore;

        public MessageBroker(
            WorkflowStore workflowStore,
            WorkerStore workerStore)
        {
            this.workflowStore = workflowStore;
            this.workerStore = workerStore;
        }

        private IConnection receiveConnection;
        private IModel receiveChannel;

        private IConnection sendConnection;
        private IModel sendChannel;
               
        public void Connect()
        {
            var factory = new ConnectionFactory() { DispatchConsumersAsync = true };
            receiveConnection = factory.CreateConnection();
            receiveChannel = receiveConnection.CreateModel();

            sendConnection = factory.CreateConnection();
            sendChannel = sendConnection.CreateModel();

            receiveChannel.QueueDeclare(
                queue: "hello",
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            var consumer = new AsyncEventingBasicConsumer(receiveChannel);
            consumer.Received += OnReceived; ;

            receiveChannel.BasicConsume(
                queue: "hello",
                autoAck: true,
                consumer: consumer);
        }

        private async Task OnReceived(object sender, BasicDeliverEventArgs e)
        {
            var body = e.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            var tokens = message.Split('.');
            var workflow = workflowStore.GetWorkflow(tokens[0]);
            var worker = workerStore.GetWorker(tokens[1]);
            var input = new WorkerInput();
            await Task.Delay(250);
            worker.Process(input, workflow);
        }

        public void Send(Message message)
        {
            var workflow = workflowStore.GetWorkflow(message.Content);
            workflow.Start(message);
        }

        public void Send(WorkerInput input, IWorker worker, IWorkflow workflow)
        {
            var workerKey = workerStore.GetKey(worker);
            var workflowKey = workflowStore.GetKey(workflow);
            var message = $"{workflowKey}.{workerKey}";
            var body = Encoding.UTF8.GetBytes(message);

            sendChannel.BasicPublish(
                exchange: "",
                routingKey: "hello",
                basicProperties: null,
                body: body);
        }

        public void Dispose()
        {
            receiveConnection.Dispose();
            receiveChannel.Dispose();
            sendConnection.Dispose();
            sendChannel.Dispose();
        }
    }
}
