using AP.Processing;
using AP.Processing.Async.CDM.Export;

namespace AP.CDM
{
    public class RequestBasedCdmExporter : IRequestBasedCdmExporter
    {
        public Message Export(Message request)
        {
            return new Message
            {
                DocumentType = "SYN003",
                Direction = Direction.Out
            };
        }
    }
}
