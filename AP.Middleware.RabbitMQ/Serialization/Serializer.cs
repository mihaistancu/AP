using AP.Async;
using System.Text;

namespace AP.Middleware.RabbitMQ.Serialization
{
    public class Serializer
    {
        private readonly Map<Workflow> workflowMap;
        private readonly Map<IWorker> workerMap;

        public Serializer(
            Map<Workflow> workflowMap,
            Map<IWorker> workerMap)
        {
            this.workflowMap = workflowMap;
            this.workerMap = workerMap;
        }

        public byte[] Serialize(Context context, Message message)
        {
            var workerId = workerMap.Id(context.Worker);
            var workflowId = workflowMap.Id(context.Workflow);
            var serialization = $"{workflowId}.{workerId}.{message.Content}";
            return Encoding.UTF8.GetBytes(serialization);
        }

        public (Context, Message) Deserialize(byte[] body)
        {
            var serialization = Encoding.UTF8.GetString(body);
            var tokens = serialization.Split('.');
            var context = new Context
            {
                Workflow = workflowMap.Get(tokens[0]),
                Worker = workerMap.Get(tokens[1])
            };
            var message = new Message
            {
                Content = tokens[2],
                SedType = tokens[2]
            };
            return (context, message);
        }
    }
}
