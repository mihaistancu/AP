using Newtonsoft.Json.Linq;
using System;
using System.Text;

namespace AP.Processing.Async
{
    public class MessageBroker
    {
        private IBroker broker;
        private IWorkers workers;

        public MessageBroker(IBroker broker, IWorkers workers)
        {
            this.broker = broker;
            this.workers = workers;
        }

        public void Start(Action<IWorker, Message> handler)
        {
            broker.Start(bytes => Handle(bytes, handler));
        }

        private void Handle(byte[] bytes, Action<IWorker, Message> handler)
        {
            var text = Encoding.UTF8.GetString(bytes);
            var json = JObject.Parse(text);

            var workerId = json.Value<string>("workerId");
            var worker = workers.Worker(workerId);

            var message = new Message
            {
                UseCase = json.Value<string>("useCase"),
                Domain = json.Value<string>("domain"),
                DocumentType = json.Value<string>("documentType"),
                EnvelopeType = json.Value<string>("envelopeType")
            };

            handler.Invoke(worker, message);
        }

        public void Send(IWorker worker, Message message)
        {
            var workerId = workers.Id(worker);

            var json = new JObject(
                new JProperty("workerId", workerId),
                new JProperty("useCase", message.UseCase),
                new JProperty("domain", message.Domain),
                new JProperty("envelopeType", message.EnvelopeType),
                new JProperty("documentType", message.DocumentType));

            var text = json.ToString();
            var bytes = Encoding.UTF8.GetBytes(text);

            broker.Send(bytes);
        }
    }
}
