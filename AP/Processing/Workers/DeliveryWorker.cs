namespace AP.Processing.Workers
{
    public class DeliveryWorker : IWorker
    {
        public string Step => "Delivery";

        public void Process(WorkerInput input, Workflow workflow)
        {
        }
    }
}
