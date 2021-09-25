using AP.Messaging;
using Newtonsoft.Json.Linq;
using System;
using System.Text;

namespace AP.Orchestration
{
    public class MessageBroker
    {
        private IBroker broker;

        public MessageBroker(IBroker broker)
        {
            this.broker = broker;
        }

        public IDisposable Start(Action<string, Message> handler)
        {
            return broker.Start(bytes => Handle(bytes, handler));
        }

        private void Handle(byte[] bytes, Action<string, Message> handler)
        {
            var text = Encoding.UTF8.GetString(bytes);
            var json = JObject.Parse(text);

            var workerName = json.Value<string>("workerName");

            var message = new Message
            {
                UseCase = json.Value<string>("useCase"),
                Domain = json.Value<string>("domain"),
                DocumentType = json.Value<string>("documentType"),
                EnvelopeType = json.Value<string>("envelopeType")
            };

            handler.Invoke(workerName, message);
        }

        public void Send(string workerName, Message message)
        {
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
