using AP.Data;
using AP.Processing.Async.CDM.Report;

namespace AP.CDM
{
    public class CdmReportBuilder : ICdmReportBuilder
    {
        public Message Build()
        {
            return new Message
            {
                DocumentType = "SYN005",
                Direction = Direction.Out
            };
        }
    }
}
