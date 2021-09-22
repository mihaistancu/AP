using AP.Middleware.RabbitMQ;
using AP.Middleware.RabbitMQ.Serialization;
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
            Serializer serializer) 
            : base(config, storage, serializer)
        {
        }

        public override void ProcessAsync(params Message[] messages)
        {
            try
            {
                base.ProcessAsync(messages);
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
