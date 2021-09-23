using AP.Processing;
using AP.Processing.Async;
using Newtonsoft.Json.Linq;
using System;
using System.Text;

namespace AP.Middleware.RabbitMQ
{
    public class MessageBroker: IDisposable
    {
        private Broker broker;
        private IWorkers workers;

        public Action<IWorker, Message> Handler { get; set; }

        public MessageBroker(Broker broker, IWorkers workers)
        {
            this.broker = broker;
            this.workers = workers;
        }

        public void Start()
        {
            broker.Handler = Handle;
            broker.Start();
        }

        public void Handle(byte[] bytes)
        {
            var text = Encoding.UTF8.GetString(bytes);
            var json = JObject.Parse(text);

            var workerId = json.Value<string>("workerId");
            var worker = workers.Worker(workerId);

            var message = new Message
            {
                Url = json.Value<string>("url"),
                DocumentType = json.Value<string>("documentType"),
                EnvelopeType = json.Value<string>("envelopeType")
            };

            Handler.Invoke(worker, message);
        }

        public void Send(IWorker worker, Message message)
        {
            var workerId = workers.Id(worker);

            var json = new JObject(
                new JProperty("workerId", workerId),
                new JProperty("url", message.Url),
                new JProperty("envelopeType", message.EnvelopeType),
                new JProperty("documentType", message.DocumentType));

            var text = json.ToString();
            var bytes = Encoding.UTF8.GetBytes(text);

            broker.Send(bytes);
        }

        public void Dispose()
        {
            broker.Dispose();
        }
    }
}
