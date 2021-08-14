namespace AP.Processing.Workers
{
    public class DeliveryWorker : IWorker
    {
        public void Process(Work work, IWorkflow workflow)
        {
            System.Console.WriteLine("Delivery");

            workflow.Done(work);
        }
    }
}
