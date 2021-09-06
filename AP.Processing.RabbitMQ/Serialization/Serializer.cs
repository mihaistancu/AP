using System.Text;

namespace AP.Processing.RabbitMQ.Serialization
{
    public class Serializer
    {
        private readonly Map<IWorkflow> workflowMap;
        private readonly Map<Worker> workerMap;

        public Serializer(
            Map<IWorkflow> workflowMap,
            Map<Worker> workerMap)
        {
            this.workflowMap = workflowMap;
            this.workerMap = workerMap;
        }

        public byte[] Serialize(Work input)
        {
            var workerId = workerMap.Id(input.Worker);
            var workflowId = workflowMap.Id(input.Workflow);
            var message = $"{workflowId}.{workerId}.{input.Message}";
            return Encoding.UTF8.GetBytes(message);
        }

        public Work Deserialize(byte[] body)
        {
            var message = Encoding.UTF8.GetString(body);
            var tokens = message.Split('.');
            return new Work
            {
                Workflow = workflowMap.Get(tokens[0]),
                Worker = workerMap.Get(tokens[1]),
                Message = new Message
                {
                    Content = tokens[2],
                    SedType = tokens[2]
                }
            };
        }
    }
}
