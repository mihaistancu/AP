using AP.Processing;
using AP.Processing.Async.CDM.Report;

namespace AP.CDM
{
    public class CdmReportFactory : ICdmReportFactory
    {
        public Message Get()
        {
            return new Message
            {
                DocumentType = "SYN005",
                Direction = Direction.Out
            };
        }
    }
}
