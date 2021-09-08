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

        public byte[] Serialize(IWorker worker, Workflow workflow, Message message)
        {
            var workerId = workerMap.Id(worker);
            var workflowId = workflowMap.Id(workflow);
            var serialization = $"{workflowId}.{workerId}.{message.Content}";
            return Encoding.UTF8.GetBytes(serialization);
        }

        public (IWorker, Workflow, Message) Deserialize(byte[] body)
        {
            var serialization = Encoding.UTF8.GetString(body);
            var tokens = serialization.Split('.');

            var workflow = workflowMap.Get(tokens[0]);
            var worker = workerMap.Get(tokens[1]);
            var message = new Message
            {
                Content = tokens[2],
                SedType = tokens[2]
            };
            return (worker, workflow, message);
        }
    }
}
