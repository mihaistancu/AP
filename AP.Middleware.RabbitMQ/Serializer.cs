using AP.Data;
using AP.Processing.Async;
using System.Text;

namespace AP.Middleware.RabbitMQ.Serialization
{
    public abstract class Serializer
    {
        public byte[] Serialize(IWorker worker, Message message)
        {
            var workerId = Serialize(worker);
            var serialization = $"{workerId}#{message.DocumentType}";
            return Encoding.UTF8.GetBytes(serialization);
        }

        public (IWorker, Message) Deserialize(byte[] body)
        {
            var serialization = Encoding.UTF8.GetString(body);
            var tokens = serialization.Split('#');

            var worker = Deserialize(tokens[0]);
            var message = new Message
            {
                DocumentType = tokens[1]
            };
            return (worker, message);
        }

        protected abstract string Serialize(IWorker worker);

        protected abstract IWorker Deserialize(string worker);
    }
}
