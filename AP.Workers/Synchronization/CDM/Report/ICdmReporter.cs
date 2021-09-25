using AP.Messages;

namespace AP.Workers.Synchronization.CDM.Report
{
    public interface ICdmReporter
    {
        Message GetReport();
    }
}
