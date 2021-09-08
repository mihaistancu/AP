using AP.Processing.Async.Workers.CDM.Report;

namespace AP.CDM
{
    public class CdmReportBuilder : ICdmReportBuilder
    {
        public Message Build()
        {
            return new Message
            {
                SedType = "SYN005",
                Content = "SYN005"
            };
        }
    }
}
