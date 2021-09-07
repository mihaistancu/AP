using System;

namespace AP.Async.Workers.Delivery
{
    public class DeliveryWorker : Worker
    {
        private readonly IRouter router;

        public DeliveryWorker(IRouter router)
        {
            this.router = router;
        }

        public override void Do(Work work)
        {
            Console.WriteLine("Delivery");

            router.Route(work.Message);

            work.Workflow.Done(work);
        }

        public override void Handle(Exception exception, Work work)
        {

        }
    }
}
