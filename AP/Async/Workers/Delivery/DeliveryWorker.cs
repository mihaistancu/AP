using System;
using System.Collections.Generic;

namespace AP.Async.Workers.Delivery
{
    public class DeliveryWorker : IWorker
    {
        private readonly IRouter router;

        public DeliveryWorker(IRouter router)
        {
            this.router = router;
        }

        public IEnumerable<Message> Handle(Message message)
        {
            Console.WriteLine("hello");
            Console.WriteLine("Delivery");

            router.Route(message);

            yield return message;
        }
    }
}
