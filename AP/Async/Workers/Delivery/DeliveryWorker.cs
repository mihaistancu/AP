using System;

namespace AP.Async.Workers.Delivery
{
    public class DeliveryWorker : IWorker
    {
        private readonly IRouter router;

        public DeliveryWorker(IRouter router)
        {
            this.router = router;
        }

        public Message[] Handle(Message message)
        {
            Console.WriteLine("Delivery");

            router.Route(message);

            return new[] { message };
        }
    }
}
