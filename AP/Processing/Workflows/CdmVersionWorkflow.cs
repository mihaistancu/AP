using AP.Processing.Workers;

namespace AP.Processing.Sequences
{
    public class CdmVersionWorkflow: LinearWorkflow
    {
        public CdmVersionWorkflow(
            IMessageBroker broker,
            AntimalwareWorker antimalware,
            ValidationWorker validation,
            CdmVersionReportWorker cdmVersionReport,
            DeliveryWorker delivery,
            ArchivingWorker archiving)
            : base(broker, new Sequence(antimalware, validation, cdmVersionReport, delivery, archiving))
        {
        }
    }
}
