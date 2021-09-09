using AP.Data;

namespace AP.Processing.Async.Workers.CDM.Report
{
    public interface ICdmReportBuilder
    {
        Message Build();
    }
}
