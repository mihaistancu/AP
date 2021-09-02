using AP.Processing.RabbitMQ.Serialization.Stores;
using System.Text;

namespace AP.Processing.RabbitMQ.Serialization
{
    public class Serializer
    {
        private readonly WorkflowStore workflowStore;
        private readonly WorkerStore workerStore;

        public Serializer(
            WorkflowStore workflowStore,
            WorkerStore workerStore)
        {
            this.workflowStore = workflowStore;
            this.workerStore = workerStore;
        }

        public byte[] Serialize(Work input)
        {
            var workerId = workerStore.Id(input.Worker);
            var workflowId = workflowStore.Id(input.Workflow);
            var message = $"{workflowId}.{workerId}";
            return Encoding.UTF8.GetBytes(message);
        }

        public Work Deserialize(byte[] body)
        {
            var message = Encoding.UTF8.GetString(body);
            var tokens = message.Split('.');
            return new Work
            {
                Workflow = workflowStore.Get(tokens[0]),
                Worker = workerStore.Get(tokens[1])
            };
        }
    }
}
