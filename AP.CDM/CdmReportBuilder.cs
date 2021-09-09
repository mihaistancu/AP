using AP.Data;
using AP.Processing.Async.Workers.CDM.Report;

namespace AP.CDM
{
    public class CdmReportBuilder : ICdmReportBuilder
    {
        public Message Build()
        {
            return new Message
            {
                DocumentType = "SYN005"
            };
        }
    }
}
