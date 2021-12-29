using AP.Messages;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
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
            return broker.Start(command => Handle(command, handler));
        }

        private void Handle(Command command, Action<string, Message> handler)
        {
            var text = Encoding.UTF8.GetString(command.Payload);
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

            broker.Send(new Command
            {
                Headers = new Dictionary<string, object>(),
                Payload = Encoding.UTF8.GetBytes(text)
            });
        }
    }
}
