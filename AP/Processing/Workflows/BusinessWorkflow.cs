using AP.Processing.Workers;

namespace AP.Processing.Sequences
{
    public class BusinessWorkflow: LinearWorkflow
    {
        public BusinessWorkflow(
            IMessageBroker broker,
            AntimalwareWorker antimalware,
            ValidationWorker validation,
            DeliveryWorker delivery,
            ArchivingWorker archiving) 
            : base(broker, new Sequence(antimalware, validation, delivery, archiving))
        {
        }
    }
}
