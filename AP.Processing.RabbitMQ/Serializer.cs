using System.Text;

namespace AP.Processing.RabbitMQ
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
            var workerKey = workerStore.GetId(input.Worker);
            var workflowKey = workflowStore.GetId(input.Workflow);
            var message = $"{workflowKey}.{workerKey}";
            return Encoding.UTF8.GetBytes(message);
        }

        public Work Deserialize(byte[] body)
        {
            var message = Encoding.UTF8.GetString(body);
            var tokens = message.Split('.');
            return new Work
            {
                Workflow = workflowStore.GetWorkflow(tokens[0]),
                Worker = workerStore.GetWorker(tokens[1])
            };
        }
    }
}
