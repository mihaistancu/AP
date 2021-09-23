using AP.Middleware.RabbitMQ;
using AP.Processing;
using AP.Processing.Async;
using System;

namespace AP.Monitoring
{
    public class MonitoredRabbitMqOrchestrator : RabbitMqOrchestrator
    {
        public MonitoredRabbitMqOrchestrator(
            IOrchestratorConfig config, 
            IMessageStorage storage, 
            MessageBroker broker) 
            : base(config, storage, broker)
        {
        }

        public override void ProcessAsync(Message message)
        {
            try
            {
                base.ProcessAsync(message);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        public override void Handle(IWorker worker, Message message)
        {
            try
            {
                base.Handle(worker, message);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }
    }
}
