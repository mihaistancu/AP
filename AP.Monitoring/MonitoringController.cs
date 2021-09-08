using AP.Processing;
using AP.Processing.Async;
using AP.Signals;
using System;

namespace AP.Monitoring
{
    public class MonitoringController: Controller
    {
        public MonitoringController(
            MessageBroker broker, 
            IErrorFactory errorFactory) 
            : base(broker, errorFactory)
        {
        }

        public override string Handle(Message message)
        {
            Console.WriteLine("Controller");
            return base.Handle(message);
        }
    }
}
