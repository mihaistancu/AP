using AP.Processing;
using AP.Processing.Async;
using Newtonsoft.Json;
using System.Text;

namespace AP.Middleware.RabbitMQ.Serialization
{
    public abstract class Serializer
    {
        public byte[] Serialize(IWorker worker, Message message)
        {
            var serializedWorker = Serialize(worker);
            var serializedMessage = Serialize(message);
            var serialization = $"{serializedWorker}#{serializedMessage}";
            return Encoding.UTF8.GetBytes(serialization);
        }

        public (IWorker, Message) Deserialize(byte[] body)
        {
            var serialization = Encoding.UTF8.GetString(body);
            var tokens = serialization.Split('#');

            var worker = DeserializeWorker(tokens[0]);
            var message = DeserializeMessage(tokens[1]);
            return (worker, message);
        }

        protected abstract string Serialize(IWorker worker);

        protected abstract IWorker DeserializeWorker(string worker);

        private string Serialize(Message message)
        {
            return JsonConvert.SerializeObject(message);
        }

        private Message DeserializeMessage(string message)
        {
            return JsonConvert.DeserializeObject<Message>(message);
        }
    }
}