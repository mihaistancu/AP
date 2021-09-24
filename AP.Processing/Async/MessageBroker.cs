using Newtonsoft.Json.Linq;
using System;
using System.Text;

namespace AP.Processing.Async
{
    public class MessageBroker
    {
        private IBroker broker;
        private WorkerMap map;

        public MessageBroker(IBroker broker, WorkerMap map)
        {
            this.broker = broker;
            this.map = map;
        }

        public void Start(Action<IWorker, Message> handler)
        {
            broker.Start(bytes => Handle(bytes, handler));
        }

        private void Handle(byte[] bytes, Action<IWorker, Message> handler)
        {
            var text = Encoding.UTF8.GetString(bytes);
            var json = JObject.Parse(text);

            var workerName = json.Value<string>("workerName");
            var worker = map.Worker(workerName);

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
            var workerName = map.Name(worker);

            var json = new JObject(
                new JProperty("workerName", workerName),
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
