using AP.Messaging;
using AP.Workers.Synchronization.CDM.Report;

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
