namespace AP.Processing.Workers
{
    public class DeliveryWorker : IWorker
    {
        public void Process(Work work)
        {
            System.Console.WriteLine("Delivery");

            work.Workflow.Done(work);
        }
    }
}
