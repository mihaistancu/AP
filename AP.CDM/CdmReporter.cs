using AP.Processing;
using AP.Processing.Async.Synchronization.CDM.Report;

namespace AP.CDM
{
    public class CdmReporter : ICdmReporter
    {
        public Message GetReport()
        {
            return new Message();
        }
    }
}
